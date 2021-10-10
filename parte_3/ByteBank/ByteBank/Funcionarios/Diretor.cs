using System;

namespace ByteBank.Funcionarios
{
    //public class Diretor : Funcionario // ':' dois pontos e o nome da classe a gente atribui herança
    public class Diretor : FuncionarioAutenticavel // ':' dois pontos e o nome da classe a gente atribui herança
    {
        //Construtor classe diretor
        public Diretor(string cpf) : base(5000, cpf)
        {
            Console.WriteLine("Chamado construtor classe DIRETOR");
        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }

        //Aqui usamos o override pra dizer que este método sobrescreve o método da classe pai
        public override double GetBonificacao()
        {
            // Usamos o base para referenciar uma chamada do método da classe pai, da classe base. pois sem ele ficaria um loop
            // no método em questão.
            return Salario * 0.5;
        }
    }
}
