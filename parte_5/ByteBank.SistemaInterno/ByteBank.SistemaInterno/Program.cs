using ByteBank.Modelos;

namespace ByteBank.SistemaInterno
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(2, 22345234);
            conta.Sacar(10);

            System.Console.WriteLine(conta.Saldo);

            System.Console.ReadLine();
        }
    }
}
