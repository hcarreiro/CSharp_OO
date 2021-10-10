using System;
using System.IO;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("CATCH NO MÉTODO MAIN.");
            }

            Console.WriteLine("\nTecle Enter para sair...");
            Console.ReadLine();
        }

        private static void CarregarContas()
        {
            // Através do using que obriga as classes que o vão utilizar implementar o método Dispose()
            // da interface IDisposable podemos trabalhar com implementações onde são necessárias a liberação
            // de um recurso pós execução ex.: um arquivo aberto, uma conexão aberta etc.
            using (LeitorDeArquivos leitor = new LeitorDeArquivos("teste.txt"))
            {
                leitor.LerProximaLinha();
            }
            

            //-------------------------------------------------------------
            
            //try
            //{
            //    leitor = new LeitorDeArquivos("contas1.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();               
            //}
            //finally
            //{
            //    Console.WriteLine("Executando o Finally.");
            //    if (leitor != null)
            //    {
            //        leitor.Fechar();
            //    }
            //}
        }

        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(1, 22344542);
                ContaCorrente conta2 = new ContaCorrente(1, 26798762);

                //conta1.Transferir(10000, conta2);
                conta1.Sacar(10004);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

        }
       
        // Teste com a cadeia de chamada:
        // Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
                int resultado = Dividir(10, divisor);
                Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Exceção com o número: {numero} e divisor: {divisor}");
                throw; //usado para passar a exeption adiante para tratamento
                Console.WriteLine("Código depois do throw");
            }
        }        
    }
}