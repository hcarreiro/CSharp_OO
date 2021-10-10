using System;

namespace _06_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente();
            Cliente cliente = new Cliente();

            cliente.Nome = "Carreiro";
            cliente.Cpf = "246.645.234-99";
            cliente.Profissao = "Desenvolvedor C#";

            conta.Saldo = -10;
            conta.Titular = cliente;

            Console.WriteLine($"Titular: {conta.Titular.Nome}");
            Console.WriteLine($"Saldo: R${conta.Saldo:F2}");

            Console.WriteLine();
            conta.Saldo = 50;

            Console.WriteLine($"Titular: {conta.Titular.Nome}");
            Console.WriteLine($"Saldo: R${conta.Saldo:F2}");

            Console.ReadLine();
        }
    }
}
