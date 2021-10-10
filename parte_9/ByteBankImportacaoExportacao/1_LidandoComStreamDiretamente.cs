using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void LidandoComFileStreamDiretamente()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                // criamos um array de 1024 bytes que é igual a 1kb
                var buffer = new byte[1024];

                // pega o retorno do método read com a qtd de bytes lidos (0 = nenhum byte foi lido, o arquivo terminou)
                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    // numeroDeBytesLidos receberá a qtd de bytes lidos retornado pelo método Read, se 0 o arquivo foi todo lido.
                    // Dizemos que nosso array é o array buffer, que deverá começar a preencher a partir do index 0
                    // e a leitura deverá ser de 1024 em 1024 bytes e alocados no array buffer.
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    Console.WriteLine($"bytes lidos: {numeroDeBytesLidos}");

                    LerEscreverBuffer(buffer, numeroDeBytesLidos);
                }
            }

            // Funão desativada porque estamos usando o using e ele implementa IDiposable
            //// Método para liberar o recurso utilizado o arquivo texto em questão
            //fluxoDoArquivo.Close();
        }

        // Método para ler e escrever os bytes do array chamado buffer
        //static void LerEscreverBuffer(byte[] buffer)
        static void LerEscreverBuffer(byte[] buffer, int bytesLidos)
        {
            //// Declaro uma variável com o padrão UTF8 para realizar o encoding de bytes para UTF8
            //var utf8 = new UTF8Encoding();

            // Podemos usar o encoding default que é o do sistema operacional. Como o arquivo foi gerado 
            // nesta máquina usar o default desta máquina não há problemas.
            var utf8 = Encoding.Default;

            //-- Nova implementação informando o início e fim do buffer a ser lido para não repetirmos valores sempre imprimindo todo o buffer
            //-- quanto estivermos no fim do arquivo.
            //// Agora converto esse array de bytes de byte para UTF8 e armazeno em uma string
            //var texto = utf8.GetString(buffer);
            //Console.Write(texto);

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            //// Realiza a leitura do array de bytes, byte a byte
            //foreach(var myByte in buffer)
            //{
            //    // Escreve cada byte lido do nosso array buffer
            //    Console.Write(myByte);
            //    Console.Write(" ");
            //}
        }

        static void RetornarTempoEDiaDaSemana()
        {
            string range1 = "06:00:00";
            string range2 = "19:59:59";

            DateTime data1 = Convert.ToDateTime(range1);
            DateTime data2 = Convert.ToDateTime(range2);

            Console.WriteLine(data1);

            if (DateTime.Now > data1 && DateTime.Now < data2)
            {
                Console.WriteLine("Range: 06:00:00 e 19:59:59");
            }
            else
            {
                Console.WriteLine("Range: diferente");
            }

            if (DateTime.Now.ToString("ddd").Equals("sab") || DateTime.Now.ToString("ddd").Equals("dom"))
            {
                Console.WriteLine("Fim de semana");
            }
            else
            {
                Console.WriteLine("Dia de semana");
            }

            //// Pegar hora minuto e segundos atuais.
            //Console.WriteLine($"Hora, min e seg: {DateTime.Now.ToString("HH:mm:ss")}");
            // Pegar o dia da semana
            //Console.WriteLine($"Dia da semana: {DateTime.Now.ToString("ddd")}");
        }
    }

}