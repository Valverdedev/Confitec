using Domain;

namespace Application
{
    public class ObjetoDeRetorno<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Data { get; set; }

        public ObjetoDeRetorno(bool sucesso, string mensagem, T data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public static ObjetoDeRetorno<T> Ok(T data, string mensagem = "Operação realizada com sucesso")
        {
            return new ObjetoDeRetorno<T>(true, mensagem, data);
        }

        public static ObjetoDeRetorno<T> Falha(string mensagem)
        {
            return new ObjetoDeRetorno<T>(false, mensagem, default(T));
        }
    }
}
