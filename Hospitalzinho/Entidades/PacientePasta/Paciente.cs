using System;
using System.Collections.Generic;
using Hospitalzinho.Enum;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class Paciente
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string CNS { get; set; } // Cartão Nacional de Saúde
        public virtual string Cpf { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string NomePai { get; set; }
        public virtual string NomeMae { get; set; }
        public virtual string CpfPai { get; set; }
        public virtual string CpfMae { get; set; }
        public virtual bool Atividade { get; set; }
        public virtual SexoPaciente Sexo { get; set; }
        public virtual string Nacionalidade { get; set; }
        public virtual RacaPaciente Raca { get; set; }
        public virtual string Naturalidade { get; set; }
        public virtual EscolaridadePaciente Escolaridade { get; set; }
        public virtual IList<PacienteContato> Contatos { get; set; } = new List<PacienteContato>();
        public virtual IList<PacienteEndereco> Enderecos { get; set; } = new List<PacienteEndereco>();
        public virtual DateTime DataCadastro { get; set; }
        public virtual DateTime DataAtualizacao { get; set; }

        public virtual PacienteProntuario Prontuario { get; set; }
    }
}