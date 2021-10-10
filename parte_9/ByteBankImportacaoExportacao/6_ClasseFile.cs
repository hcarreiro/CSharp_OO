using System;
using System.IO;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsandoClasseFile()
        {
            // A Classe File pode ser usada quando temos leitura e escrita de arquivos pequenos
            // Ela é mais simples de ser implementada pois não há necessidade de controle de buffer etc.

            // Criar um novo arquivo passando o conteúdo como parâmetro
            File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");

            // Retorna um array de bytes.
            var bytesArquivo = File.ReadAllBytes("contas.txt");
            // Retorna a quantidade de bytes do arquivo.
            Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes");

            // Retorna um array de string com cada linha
            var linhas = File.ReadAllLines("contas.txt");
            // Retorna a quantidade de linhas do arquivo.
            Console.WriteLine(linhas.Length);

            // Exibe todas as linhas
            foreach(var linha in linhas)
            {
                Console.WriteLine(linha);
            }
        }
    }
}
