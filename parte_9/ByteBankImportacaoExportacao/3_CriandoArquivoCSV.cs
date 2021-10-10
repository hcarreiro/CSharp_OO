using ByteBankImportacaoExportacao.Modelos;
using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "456,78945,4785.50,Gustavo Santos";
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComoString);

                // Escrita de arquivo de forma mais "arcaica" usando array de bytes pego pelo encoding
                fluxoDeArquivo.Write(bytes, 0, bytes.Length);

                Console.WriteLine("Arquivo criado lidando com bytes com sucesso!");
            }
        }

        /* Processo de criação de arquivos através do StreamWriter
         * Forma mais elegante que a anterior usada no CriarArquivo() */
        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            // Como tanto FileStream quanto StreamWriter implementam a interface IDisposable
            // Ambos devem implementar o método IDispose e então para facilitar usamos o using
            // Também é importante observar que estamos usando o FileMode.Create que cria um novo arquivo e sobrecreve
            // caso haja um arquivo com o mesmo nome no destino. Se alterarmos para o FileMode.CreateNew ele vai analisar
            // o destino antes para saber se já existe um arquivo com este nome caso não cria este arquivo, caso haja já 
            // um arquivo com este nome ele lança uma exception
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            // Por padrão ele está utilizando o encoding default
            //using (var escritor = new StreamWriter(fluxoDeArquivo))
            using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {
                
                escritor.Write("123,32145,125.77,Pedro Augusto");
            }

            Console.WriteLine("Arquivo criado pelo StreamWriter com sucesso!");
        }

        /* Processo de criação de arquivo usando o Flush para despejo de memória
        * técnica recomendada para situações de gravação de log por exemplo onde cada novo
        * dado deve ser adicionado ao arquivo de log assim que capturado pois se a aplicação quebrar
        * e os dados estiverem em buffer serão perdidos*/
        static void CriarArquivoComFlush()
        {
            var caminhoNovoArquivo = "exemploTesteLog.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                for (int i = 0; i < 100; i++)
                {
                    escritor.WriteLine($"Escrita da linha {i}");

                    escritor.Flush(); // Método que fará o despejo do buffer no arquivo

                    Console.WriteLine($"Linha {i} escrita no arquivo... Tecle Enter para continuar");
                    Console.ReadLine();
                }                
            }
        }
    }
}
