using System;

namespace _05_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Forma 1 de se fazer
            Cliente gabriela = new Cliente();
            gabriela.nome = "Gabriela";
            gabriela.cpf = "434.562.878-20";
            gabriela.profissao = "Desenvolvedora C#";
            */

            //Forma 2 de se fazer
            ContaCorrente conta = new ContaCorrente();
            //conta.titular = gabriela;
            conta.cliente = new Cliente();
            conta.cliente.nome = "Gabriela Costa";
            conta.cliente.cpf = "434.562.878-20";
            conta.cliente.profissao = "Desenvolvedora C#";
            conta.saldo = 500;
            conta.agencia = 563;
            conta.conta = 5634527;


            //Console.WriteLine($"Nome titular: {gabriela.nome}");
            Console.WriteLine("Nome: {0}", conta.cliente.nome);
            Console.WriteLine($"CPF: {conta.cliente.cpf}");
            Console.WriteLine("Profissão: " + conta.cliente.profissao);

            Console.ReadLine();
        }
    }
}
