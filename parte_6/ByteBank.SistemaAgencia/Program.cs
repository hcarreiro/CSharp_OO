using ByteBank.Modelos;
using System;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            TesteEquals();

            Console.ReadLine();
        }

        static void ClasseObject()
        {
            // Como toda classe deriva de object a implementação de vários métodos do C# .Net usam o object
            // um exemplo é o:
            //public static void WriteLine(object value);
            //que usa um object como parâmetro que por sua vez usa um ToString
            //E como o ToString é um método virtual ele pode ser sobrescrito com uma nova implementação.
            //public virtual string ToString();
            ContaCorrente conta = new ContaCorrente(23, 2344234);
            Console.WriteLine(conta);
        }

        static void TesteEquals()
        {
            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "234.543.455-44";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "234.543.455-44";
            carlos_2.Profissao = "Designer";

            // Comparação básica sem sobrecarga
            if (carlos_1 == carlos_2)
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são igual!");
            }

            // Comparação com sobrecarga do método Equals na classe cliente.
            if (carlos_1.Equals(carlos_2))
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são igual!");
            }

        }

        static void ExpressaoRegular()
        {
            // Teste Expressão Regular
            string padrao = "Sala [A-G][-]?[0123456789]{2}";

            Console.WriteLine(Regex.IsMatch("Sala G345", padrao));
            Console.WriteLine(Regex.IsMatch("Sala J-001", padrao));
            Console.WriteLine(Regex.IsMatch("Sala a004", padrao));
            Console.WriteLine(Regex.IsMatch("Sala C004", padrao));
            Console.WriteLine(Regex.IsMatch("Minha sala é a sala G34", padrao));
            Console.WriteLine(Regex.IsMatch("Minha sala é a Sala G-34", padrao));

            string textoPadrao = "Olá meu telefone é 5586-3344 pode ligar a vontade em caso de dúvidas";

            string expressao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            //ou
            string expressao1 = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            //ou
            string expressao2 = "[0-9]{4}[-][0-9]{4}";
            //ou
            string expressao3 = "[0-9]{4,5}[-][0-9]{4}";
            //ou
            string expressao4 = "[0-9]{4}[-]{0,1}[0-9]{4}";
            //ou
            string expressao5 = "[0-9]{4}-{0,1}[0-9]{4}";
            //ou
            string expressao6 = "[0-9]{4}-?[0-9]{4}";

            Match resultado = Regex.Match(textoPadrao, expressao);
            Console.WriteLine(Regex.IsMatch(textoPadrao, expressao));
            Console.WriteLine(resultado);

            Match resultado2 = Regex.Match(textoPadrao, expressao2);
            Console.WriteLine(Regex.IsMatch(textoPadrao, expressao2));
            Console.WriteLine(resultado2);

            Match resultado3 = Regex.Match(textoPadrao, expressao3);
            Console.WriteLine(Regex.IsMatch(textoPadrao, expressao3));
            Console.WriteLine(resultado3);

            Match resultado4 = Regex.Match(textoPadrao, expressao4);
            Console.WriteLine(Regex.IsMatch(textoPadrao, expressao4));
            Console.WriteLine(resultado4);

            Match resultado5 = Regex.Match(textoPadrao, expressao5);
            Console.WriteLine(Regex.IsMatch(textoPadrao, expressao5));
            Console.WriteLine(resultado5);

            Match resultado6 = Regex.Match(textoPadrao, expressao6);
            Console.WriteLine(Regex.IsMatch(textoPadrao, expressao6));
            Console.WriteLine(resultado6);
        }

        static void ManipulaString()
        {
            //// Teste StartsWith e EndsWith
            //string url = "https://www.bytebank.com.br/cambio";

            //Console.WriteLine(url.StartsWith("https://www.bytebank.com.br"));
            //Console.WriteLine(url.EndsWith("cambio"));
            //Console.WriteLine(url.Contains(".com.br"));


            //// Teste de pegar partes de uma string
            //string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            //ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(urlParametros);

            //string valorOrigem = extratorDeValores.GetValor("moedaOrigem");
            //Console.WriteLine($"Valor de moedaOrigem: {valorOrigem}");

            //string valorDestino = extratorDeValores.GetValor("moedaDestino");
            //Console.WriteLine($"Valor de moedaDestino: {valorDestino}");

            //string valorCalculo = extratorDeValores.GetValor("valor");
            //Console.WriteLine($"Valor de moedaDestino: {valorCalculo}");


            //string palavra = "moedaOrigem=real&moedaDestino=dolar";
            //string nomeArgumento = "moedaDestino";

            //int indice = palavra.IndexOf(nomeArgumento);
            //Console.WriteLine($"resultado palavra.IndexOf(nomeArgumento): {indice}");

            //Console.WriteLine($"Tamanho da string nomeArgumento: {nomeArgumento.Length}");

            //Console.WriteLine($"Palavra: {palavra}");
            //Console.WriteLine($"Palavra substring: {palavra.Substring(indice)}");
            //Console.WriteLine($"Palavra substring + indice + tamanho argumento + 1: {palavra.Substring(indice + nomeArgumento.Length + 1)}");




            //// Testando o IsNullOrEmpty
            //string textoVazio = "";
            //string textoNulo = null;
            //string textoQualquer = "kjhfsdjhgsdfjksdf";

            //Console.WriteLine(String.IsNullOrEmpty(textoVazio));
            //Console.WriteLine(String.IsNullOrEmpty(textoNulo));
            //Console.WriteLine(String.IsNullOrEmpty(textoQualquer));
            //Console.ReadLine();

            //ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL("");

            //string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            //int indiceInterrogacao = url.IndexOf('?');

            //Console.WriteLine(indiceInterrogacao);

            //Console.WriteLine(url);
            //string argumentos = url.Substring(indiceInterrogacao + 1);
            //Console.WriteLine(argumentos);

        }
    }
}
