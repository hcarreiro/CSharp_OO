using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDaGabriela = new ContaCorrente();
            contaDaGabriela.titular = "Gabriela";
            contaDaGabriela.agencia = 863;
            contaDaGabriela.conta = 863452;

            ContaCorrente contaDaGabrielaCosta = new ContaCorrente();
            contaDaGabrielaCosta.titular = "Gabriela";
            contaDaGabrielaCosta.agencia = 863;
            contaDaGabrielaCosta.conta = 863452;

            // Essa comparação da false porque estamos validando a referência por serem tipos referência e não valor
            Console.WriteLine($"Igualdade de tipo de referência: {contaDaGabriela == contaDaGabrielaCosta}");

            int idade = 27;
            int idadeMaisUmaVez = 27;

            Console.WriteLine($"Igualdade do tipo valor: {idade == idadeMaisUmaVez}");

            // Essa comparação da true porque estamos validando o tipo valor do titular do objeto e não a referência
            Console.WriteLine("Igualdade do tipo valor: {0}",contaDaGabriela.titular == contaDaGabrielaCosta.titular);

            //Neste ponto eu digo que contaDaGabrielaCosta deve apontar para mo mesmo endereço de memória de contaDaGabriela
            contaDaGabriela = contaDaGabrielaCosta;

            // Essa comparação AGORA da true porque ambos agora apontam para o mesmo endereço de memória
            Console.WriteLine($"Igualdade de tipo de referência: {contaDaGabriela == contaDaGabrielaCosta}");

            contaDaGabriela.saldo = 300;

            //Exemplo prático, alterei o valor do saldo na instrução anterior de contaDaGabriela para 300
            //Pedimos agora para imprimir o saldo de ambas as contas e como ambas apontam para a mesma refência de memória
            //o valor a ser exibido é o mesmo.
            Console.WriteLine($"Saldo: R${contaDaGabriela.saldo}");
            Console.WriteLine("Saldo: R${0}", contaDaGabrielaCosta.saldo);

            Console.ReadLine();
        }
    }
}
