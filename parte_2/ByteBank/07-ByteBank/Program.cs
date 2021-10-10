using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(867, 86712540);
            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);

            Console.WriteLine($"Agência: {conta.Agencia}");
            Console.WriteLine("Conta: {0}", conta.Conta);

            ContaCorrente contaDaGabriela = new ContaCorrente(867, 86745820);
            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);

            Console.WriteLine($"Agência: {contaDaGabriela.Agencia}");
            Console.WriteLine("Conta: {0}", contaDaGabriela.Conta);


            Console.ReadLine();
        }
    }
}
