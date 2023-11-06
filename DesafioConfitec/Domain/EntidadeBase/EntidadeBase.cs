namespace Domain
{
    public abstract class EntidadeBase
    {
        public int Id { get; private set; }
        public DateTime DataCriacao { get; }
        public DateTime DataModificacao { get; private set; }
        public bool Ativo { get; private set; } = true;

        protected EntidadeBase()
        {
            DataCriacao = DateTime.UtcNow;
        }

        internal void AtualizarDataModificacao()
        {
            DataModificacao = DateTime.UtcNow;
        }

        internal void Desativar()
        {
            if (Ativo)
            {
                Ativo = false;
                AtualizarDataModificacao();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is EntidadeBase compareTo)
            {
                return Id == compareTo.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
