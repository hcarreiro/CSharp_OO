using System;

namespace ByteBank.Funcionarios
{
    public abstract class Funcionario
    {
        public static int TotalDeFuncionarios { get; private set; }
        public string Nome { get; set; }
        public string Cpf { get; private set; }
        public double Salario { get; protected set; }

        //Construtor
        public Funcionario(double salario, string cpf)
        {
            Console.WriteLine("Chamado construtor classe FUNCIONARIO");

            TotalDeFuncionarios++;

            Cpf = cpf;
            Salario = salario;
        }

        /*
        public virtual void AumentarSalario()
        {
            // Como todos as classes filhas tem sua própria implementação não utilizando a da classe Funcionário e o override é obrigatório,
            // ou seja, é obrigatório que cada classe tenha um implementação desses métodos. Vamos apenas por um aviso no método.
            //Salario *= 1.1;

            Console.WriteLine("Atenção! Não esqueça de sobrescever o método AumentarSalario.");
        }

        //Aqui usamos o virtual para informar que uma classe filha poderá ter uma implementaçao diferente para este método
        public virtual double GetBonificacao()
        {
            //return Salario * 0.10;
            Console.WriteLine("Atenção! Não esqueça de sobrescever o método GetBonificacao.");
            return 0;

        }
        */

        //Usamos a implementação com o virtual para dizer que as classes que herdam da classe Funcionário devem fazer um override dos métodos
        //Uma melhor implementação é usar o abstract assim definimos que todas as classes derivadas devem implementar estes métodos.
        public abstract void AumentarSalario();
        public abstract double GetBonificacao();
    }
}
