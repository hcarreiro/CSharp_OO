using ByteBankImportacaoExportacao.Modelos;
using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsarStreamReader()
        {
            var enderecoDoArquivo = "contas.txt";

            // Como tanto FileStream quanto StreamReader implementam a interface IDispose, ambas devem realizar a chamada do método IDiposable.
            // Assim o melhor é usarmos um using para um para que liberemos os recursos corretamente.
            // Quando temos dois using alinhados assim, podemso remover as chaves e colocá-los um abaixo do outro para serem executados em sequência.
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDoArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();

                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    var msg = $"Titular: {contaCorrente.Titular.Nome} Ag.: {contaCorrente.Agencia}, Conta: {contaCorrente.Numero}, Saldo: {contaCorrente.Saldo}";

                    Console.WriteLine(msg);
                }
            }
        }

        /* Este método tem o objetivo de ler um arquivo e carregar os dados do arquivo na memória do sistema.
         * Vamos pergar todas as contas do arquivo e carregar na memória podendo o arquivo ser alterado e não
         * havendo necessecidade de alteração no código */
        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            // anteriormente o separador era espaço mas com nomes e sobrenomes não funcionava porque parava no índice 3 o array.
            // trocamos o delimitador pra vírgula pra pegar um range correto e assim o nome completo
            var campos = linha.Split(',');

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.', ','));
            var nomeTitular = campos[3];

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado;
        }
    }
}