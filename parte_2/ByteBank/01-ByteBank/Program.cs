using System;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ContaCorrente contaDaGabriela = new ContaCorrente();

            contaDaGabriela.titular = "Gabriela";
            contaDaGabriela.agencia = 863;
            contaDaGabriela.conta = 863452;
            contaDaGabriela.saldo = 100.0;

            Console.WriteLine(contaDaGabriela.titular);
            Console.WriteLine("Agência: {0}", contaDaGabriela.agencia);
            Console.WriteLine($"Conta corrente: {contaDaGabriela.conta}");

            // Exibição de texto por Placeholder - usando o F2 para 2 casas decimais
            Console.WriteLine("Saldo: R${0:F2}", contaDaGabriela.saldo);

            // Exibição de texto por Interpolalação - usando o F2 para 2 casas decimais
            Console.WriteLine($"Saldo: R${contaDaGabriela.saldo:F2}");

            // Exibição de texto por Concatenação - para converter pra 2 casas decimais faço um ToString passando o F2
            Console.WriteLine("Saldo: R$" + contaDaGabriela.saldo.ToString("F2"));

            Console.ReadLine();
            */

            ContaCorrente primeiraContaCorrente = new ContaCorrente();
            primeiraContaCorrente.saldo = 200;
            Console.WriteLine(primeiraContaCorrente.saldo);

            primeiraContaCorrente.saldo += 100;
            Console.WriteLine(primeiraContaCorrente.saldo);

            ContaCorrente segundaContaCorrente = new ContaCorrente();
            segundaContaCorrente.saldo = 50;

            Console.WriteLine("primeira conta tem " + primeiraContaCorrente.saldo);
            Console.WriteLine("segunda conta tem " + segundaContaCorrente.saldo);

            Console.ReadLine();
        }
    }
}
