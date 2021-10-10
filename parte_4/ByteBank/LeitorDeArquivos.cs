using System;
using System.IO;

namespace ByteBank
{
    public class LeitorDeArquivos : IDisposable
    {
        public string Arquivo { get; }

        public LeitorDeArquivos(string arquivo)
        {
            Arquivo = arquivo;

            //throw new FileNotFoundException();

            Console.WriteLine($"Abrindo arquivos: {arquivo}");
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha...");

            throw new IOException();

            return "Linha do arquivo";
        }

        public void Dispose()
        {
            Console.WriteLine("Fechando arquivo...");
        }
    }
}
