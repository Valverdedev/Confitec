namespace Domain
{
    public class RegrasDeNegocioException : Exception
    {
        public RegrasDeNegocioException() { }

        public RegrasDeNegocioException(string message) : base(message) { }

        public RegrasDeNegocioException(string message, Exception inner) : base(message, inner) { }
    }
}
