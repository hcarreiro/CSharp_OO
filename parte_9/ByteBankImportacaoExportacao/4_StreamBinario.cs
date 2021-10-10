using System;
using System.IO;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void EscritaBinaria()
        {
            using (var fs = new FileStream("arquivoBinario.txt", FileMode.Create))            
            using (var escritor = new BinaryWriter(fs)) // Utilizaremos o BinaryWriter para realizar a escrita dos dados de forma binária
            {
                escritor.Write(11);             // número da agência
                escritor.Write(895647);         // número da conta
                escritor.Write(125.55);         // saldo
                escritor.Write("Paulo Cesar");  // titular
            }
        }

        static void LeituraBinaria()
        {
            using (var fs = new FileStream("arquivoBinario.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs)) // Utilizaremos o BinaryWriter para realizar a escrita dos dados de forma binária
            {
                var agencia = leitor.ReadInt32();   // número da agência
                var conta = leitor.ReadInt32();     // número da conta
                var saldo = leitor.ReadDouble();    // saldo
                var titular = leitor.ReadString();  // titular

                Console.WriteLine($"{agencia} - {conta} - {titular} - R${saldo}");
            }
        }
    }
}