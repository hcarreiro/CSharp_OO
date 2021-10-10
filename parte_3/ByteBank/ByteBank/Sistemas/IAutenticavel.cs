namespace ByteBank.Sistemas
{
    //Essa classe se torna abstrata para não ser obrigada a implementar os métodos abstratos da classe 
    //public abstract class Autenticavel : Funcionario

    //Vamos usar o conceito de interface pois agora precisamos que um membro que não é um funcionario tenha acesso
    //acesso aos membros e métodos daqui
    public interface IAutenticavel
    {
        // Métodos de interface não tem modificadores de acesso pois por default todos os métodos são públicos
        bool Autenticar(string senha);

        /*
        //Em interfaces não temos atributos, propriedades ou implementação de métodos, temos apenas uma "casca"
        //public string Senha { get; set; }

        //Contrutor da classe abstrata Autenticavel, que como herda de Funcionário que também é uma classe abstrata
        //precisa passar um salario e um cpf para a classe pai.
        protected Autenticavel(double salario, string cpf)
            : base(salario, cpf)
        {
        }

        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
        */ 
    }
}
