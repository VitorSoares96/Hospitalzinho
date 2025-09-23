using FGB.Entidades;
using FGB.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGB.Servicos
{
    public class ServicoCrud<T> : ServicoConsulta<T> where T : EntidadeBase
    {
        public event MergeHandler<T> PreMerge;

        public event MergeHandler<T> PosMerge;

        public event ExcluiHandler<T> PreExclui;

        public event ExcluiHandler<T> PosExclui;

        public event IncluiHandler<T> PreInclui;

        public event IncluiHandler<T> PosInclui;

        public ServicoCrud(IRepositorioSessao repositorio, ILogger<ServicoCrud<T>> log)
            : base(repositorio, (ILogger<ServicoConsulta<T>>)log)
        {
        }

        public virtual bool Validacoes(T entidade)
        {
            log.LogInformation("{Metodo} -> Inicio processo de validação de entidade", "Validacoes");
            base.Mensagens.Clear();
            if (ValidarAnotacoes(entidade))
            {
                return Valida(entidade);
            }

            return false;
        }

        protected virtual bool ValidarAnotacoes(T entidade)
        {
            if (entidade == null)
            {
                ArgumentNullException ex = new ArgumentNullException("entidade", "menu.mensagem.requisicao.vazia");
                log.LogError(ex, "{Metodo} -> Entidade é nula", "ValidarAnotacoes");
                base.Mensagens.Add(ex);
                return false;
            }

            List<MensagemRetorno> errosValidacaoAnotacaoRecursivo = entidade.GetErrosValidacaoAnotacaoRecursivo();
            base.Mensagens.AddRange(errosValidacaoAnotacaoRecursivo);
            if (base.Mensagens.HasErro())
            {
                log.LogInformation("{Metodo} -> Entidade não atende as validações", "ValidarAnotacoes");
                return false;
            }

            log.LogInformation("{Metodos} -> Validação de anotação feita com sucesso", "ValidarAnotacoes");
            return true;
        }

        public virtual bool Valida(T entidade)
        {
            log.LogInformation("{Metodo} -> Validação customizada da entidade tem status de {Status}", "Valida", !base.Mensagens.HasErro());
            return !base.Mensagens.HasErro();
        }

        public bool MakeCrudTransaction(Action<IRepositorio> transaction)
        {
            using (Repositorio.IniciaTransacao())
            {
                IRepositorio repositorio = Repositorio.GetRepositorio();
                log.LogInformation("{Metodo} -> Inicio processo de transação", "MakeCrudTransaction");
                try
                {
                    transaction(repositorio);
                    Repositorio.CommitaTransacao();
                }
                catch (Exception ex)
                {
                    Repositorio.RollBackTransacao();
                    base.Mensagens.Add(ex);
                    log.LogError(ex, "{Metodo} -> Erro de transação com entidade", "MakeCrudTransaction");
                }

                log.LogInformation("{Metodo} -> Fim processo de transação", "MakeCrudTransaction");
                return !base.Mensagens.HasErro();
            }
        }

        public async Task<bool> MakeCrudTransactionAsync(Func<IRepositorio, Task> transaction)
        {
            using (Repositorio.IniciaTransacao())
            {
                IRepositorio repositorio = Repositorio.GetRepositorio();
                log.LogInformation("{Metodo} -> Inicio processo de transação", "MakeCrudTransactionAsync");
                try
                {
                    await transaction(repositorio);
                    await Repositorio.CommitaTransacaoAsync();
                }
                catch (Exception ex)
                {
                    await Repositorio.RollBackTransacaoAsync();
                    base.Mensagens.Add(ex);
                    log.LogError(ex, "{Metodo} -> Erro de transação com entidade", "MakeCrudTransactionAsync");
                }

                log.LogInformation("{Metodo} -> Fim processo de transação", "MakeCrudTransactionAsync");
                return !base.Mensagens.HasErro();
            }
        }

        public virtual bool Inclui(params T[] entidades)
        {
            return ProcessoInclusao(entidades, () => MakeCrudTransaction(delegate (IRepositorio repo)
            {
                T[] array = entidades;
                foreach (T val in array)
                {
                    T val2 = val;
                    DateTime? criadoEm = val2.CriadoEm;
                    DateTime valueOrDefault = criadoEm.GetValueOrDefault();
                    if (!criadoEm.HasValue)
                    {
                        valueOrDefault = DateTime.Now;
                        DateTime? criadoEm2 = valueOrDefault;
                        val2.CriadoEm = criadoEm2;
                    }

                    val.UltimaAlteracao = DateTime.Now;
                    repo.Inclui(val);
                }
            }));
        }

        public virtual async Task<bool> IncluiAsync(params T[] entidades)
        {
            return await ProcessoInclusaoAsync(entidades, async () => await MakeCrudTransactionAsync(async delegate (IRepositorio repo)
            {
                T[] array = entidades;
                foreach (T val in array)
                {
                    val.CriadoEm = DateTime.Now;
                    val.UltimaAlteracao = DateTime.Now;
                    await repo.IncluiAsync(val);
                }
            }));
        }

        public virtual bool ProcessoInclusao(T[] entidades, Func<bool> process)
        {
            if (entidades.Length == 0)
            {
                log.LogInformation("{Metodo} -> Requisição vazia", "ProcessoInclusao");
                return true;
            }

            if (!entidades.All(Validacoes))
            {
                log.LogInformation("{Metodo} -> Entidades {Entidade} não atendem as validações", "ProcessoInclusao", entidades.ToString());
                return false;
            }

            log.LogInformation("{Metodo} -> Inicio inclusão de {Quantidade} entidades", "ProcessoInclusao", entidades.Length);
            T[] array = entidades;
            foreach (T val in array)
            {
                val.VincularColecoes();
                val.CriadoEm = DateTime.Now;
                val.UltimaAlteracao = DateTime.Now;
                this.PreInclui?.Invoke(new IncluiInfo<T>(val));
            }

            bool flag = process();
            if (flag)
            {
                array = entidades;
                foreach (T entidade in array)
                {
                    this.PosInclui?.Invoke(new IncluiInfo<T>(entidade));
                }
            }

            log.LogInformation("{Metodo} -> Fim inclusão de {Quantidade} entidades", "ProcessoInclusao", entidades.Length);
            return flag;
        }

        public virtual async Task<bool> ProcessoInclusaoAsync(T[] entidades, Func<Task<bool>> process)
        {
            if (entidades.Length == 0)
            {
                log.LogInformation("{Metodo} -> Requisição vazia", "ProcessoInclusaoAsync");
                return true;
            }

            if (!entidades.All(Validacoes))
            {
                log.LogInformation("{Metodo} -> Entidades {Entidade} não atendem as validações", "ProcessoInclusaoAsync", entidades.ToString());
                return false;
            }

            log.LogInformation("{Metodo} -> Inicio inclusão de {Quantidade} entidades", "ProcessoInclusaoAsync", entidades.Length);
            T[] array = entidades;
            foreach (T val in array)
            {
                val.VincularColecoes();
                val.CriadoEm = DateTime.Now;
                val.UltimaAlteracao = DateTime.Now;
                this.PreInclui?.Invoke(new IncluiInfo<T>(val));
            }

            bool flag = await process();
            if (flag)
            {
                array = entidades;
                foreach (T entidade in array)
                {
                    this.PosInclui?.Invoke(new IncluiInfo<T>(entidade));
                }
            }

            log.LogInformation("{Metodo} -> Fim inclusão de {Quantidade} entidades", "ProcessoInclusaoAsync", entidades.Length);
            return flag;
        }

        public virtual T Merge(T entidade)
        {
            if (!ProcessoMerge(entidade, (T entidadeOld) => MakeCrudTransaction(delegate (IRepositorio repo)
            {
                entidade.UltimaAlteracao = DateTime.Now;
                entidade.CriadoEm = entidadeOld.CriadoEm;
                entidade = repo.Merge(entidade);
            })))
            {
                return null;
            }

            return entidade;
        }

        public virtual async Task<T> MergeAsync(T entidade)
        {
            return (await ProcessoMergeAsync(entidade, async (T entidadeOld) => await MakeCrudTransactionAsync(async delegate (IRepositorio repo)
            {
                entidade.UltimaAlteracao = DateTime.Now;
                entidade.CriadoEm = entidadeOld.CriadoEm;
                T val = await repo.MergeAsync(entidade);
                entidade = val;
            }))) ? entidade : null;
        }

        protected virtual bool ProcessoMerge(T entidade, Func<T, bool> process)
        {
            if (!Validacoes(entidade))
            {
                return false;
            }

            log.LogInformation("{Metodo} -> Inicio de merge da entidade de id {Identificador}", "ProcessoMerge", entidade.Id);
            T val = Retorna(entidade.Id);
            if (val == null)
            {
                log.LogInformation("{Metodo} -> Entidade nula", "ProcessoMerge");
                return false;
            }

            entidade.VincularColecoes();
            this.PreMerge?.Invoke(new MergeInfo<T>(val, entidade));
            bool flag = process(val);
            if (!flag)
            {
                return false;
            }

            this.PosMerge?.Invoke(new MergeInfo<T>(val, entidade));
            log.LogInformation("{Metodo} -> Fim de merge da entidade de id {Identificador}", "ProcessoMerge", entidade.Id);
            return flag;
        }

        protected virtual async Task<bool> ProcessoMergeAsync(T entidade, Func<T, Task<bool>> process)
        {
            if (!Validacoes(entidade))
            {
                return false;
            }

            log.LogInformation("{Metodo} -> Inicio de merge da entidade de id {Identificador}", "ProcessoMergeAsync", entidade.Id);
            T entidadeOld = await RetornaAsync(entidade.Id);
            if (entidadeOld == null)
            {
                log.LogInformation("{Metodo} -> Entidade nula", "ProcessoMergeAsync");
                return false;
            }

            entidade.VincularColecoes();
            this.PreMerge?.Invoke(new MergeInfo<T>(entidadeOld, entidade));
            bool flag = await process(entidadeOld);
            if (!flag)
            {
                return false;
            }

            this.PosMerge?.Invoke(new MergeInfo<T>(entidadeOld, entidade));
            log.LogInformation("{Metodo} -> Fim de merge da entidade de id {Identificador}", "ProcessoMergeAsync", entidade.Id);
            return flag;
        }

        public virtual T Exclui(long id)
        {
            T val = Retorna(id);
            if (val == null)
            {
                ApplicationException ex = new ApplicationException("menu.mensagem.registro.nao.encontrado");
                log.LogError(ex, "{Metodo} -> Entidade nula em processo de exclusão", "Exclui");
                base.Mensagens.Add(ex);
                return null;
            }

            if (!Exclui(val))
            {
                return null;
            }

            return val;
        }

        public virtual bool Exclui(params T[] entidades)
        {
            return ProcessarExclusao(entidades, () => MakeCrudTransaction(delegate (IRepositorio repo)
            {
                T[] array = entidades;
                foreach (T entidade in array)
                {
                    repo.Exclui(entidade);
                }
            }));
        }

        public virtual async Task<T> ExcluiAsync(long id)
        {
            T entidade = await RetornaAsync(id);
            if (entidade == null)
            {
                ApplicationException ex = new ApplicationException("menu.mensagem.registro.nao.encontrado");
                log.LogError(ex, "{Metodo} -> Entidade nula em processo de exclusão", "ExcluiAsync");
                base.Mensagens.Add(ex);
                return null;
            }

            return (await ExcluiAsync(entidade)) ? entidade : null;
        }

        public virtual async Task<bool> ExcluiAsync(params T[] entidades)
        {
            return await ProcessarExclusaoAsync(entidades, async () => await MakeCrudTransactionAsync(async delegate (IRepositorio repo)
            {
                T[] array = entidades;
                foreach (T entidade in array)
                {
                    await repo.ExcluiAsync(entidade);
                }
            }));
        }

        protected virtual bool ProcessarExclusao(T[] entidades, Func<bool> process)
        {
            if (entidades.Length == 0)
            {
                log.LogInformation("{Metodo} -> Método excluir não recebeu entidades", "ProcessarExclusao");
                return true;
            }

            log.LogInformation("{Metodo} -> Inicio de exclusão de {Quantidade} entidades", "ProcessarExclusao", entidades.Length);
            T[] array = entidades;
            foreach (T entidade in array)
            {
                this.PreExclui?.Invoke(new ExcluiInfo<T>(entidade));
            }

            bool flag = process();
            if (flag)
            {
                log.LogInformation("{Metodo} -> Fim de exclusão de {Quantidade} entidades", "ProcessarExclusao", entidades.Length);
                array = entidades;
                foreach (T entidade2 in array)
                {
                    this.PosExclui?.Invoke(new ExcluiInfo<T>(entidade2));
                }
            }

            return flag;
        }

        protected virtual async Task<bool> ProcessarExclusaoAsync(T[] entidades, Func<Task<bool>> process)
        {
            if (entidades.Length == 0)
            {
                log.LogInformation("{Metodo} -> Método excluir não recebeu entidades", "ProcessarExclusaoAsync");
                return true;
            }

            log.LogInformation("{Metodo} -> Inicio de exclusão de {Quantidade} entidades", "ProcessarExclusaoAsync", entidades.Length);
            T[] array = entidades;
            foreach (T entidade in array)
            {
                this.PreExclui?.Invoke(new ExcluiInfo<T>(entidade));
            }

            bool flag = await process();
            if (flag)
            {
                log.LogInformation("{Metodo} -> Fim de exclusão de {Quantidade} entidades", "ProcessarExclusaoAsync", entidades.Length);
                array = entidades;
                foreach (T entidade2 in array)
                {
                    this.PosExclui?.Invoke(new ExcluiInfo<T>(entidade2));
                }
            }

            return flag;
        }
    }
}
