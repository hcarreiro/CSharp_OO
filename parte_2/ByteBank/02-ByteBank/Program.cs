using System;

namespace _02_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDaGabriela = new ContaCorrente();

            contaDaGabriela.titular = "Gabriela";
            contaDaGabriela.saldo = 200;

            Console.WriteLine(contaDaGabriela.titular);
            Console.WriteLine("Agência: {0}", contaDaGabriela.agencia);

            // Exibição de texto por Placeholder - usando o F2 para 2 casas decimais
            Console.WriteLine("Saldo: R${0:F2}", contaDaGabriela.saldo);

            // Exibição de texto por Interpolalação - usando o F2 para 2 casas decimais
            Console.WriteLine($"Saldo: R${contaDaGabriela.saldo:F2}");

            // Exibição de texto por Concatenação - para converter pra 2 casas decimais faço um ToString passando o F2
            Console.WriteLine("Saldo: R$" + contaDaGabriela.saldo.ToString("F2"));

            Console.ReadLine();
        }
    }
}
