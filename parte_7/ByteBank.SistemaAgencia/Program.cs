using ByteBank.Modelos;
using System;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            for(int i = 0; i < 200; i++)
            {
                Console.WriteLine(rand.Next(0, 999).ToString("D3"));
                Console.WriteLine(rand.Next(0, 99999999).ToString("D8"));
            }


            //Console.WriteLine(SomarVarios(1, 2, 3, 5, 56465, 45));
            //Console.WriteLine(SomarVarios(1, 2, 45));

            //Lista<int> idades = new Lista<int>();

            //idades.Adicionar(5);
            //idades.AdicionarVarios(1, 5, 78);

            //Console.WriteLine(SomarVarios(1, 2, 3, 5, 56465, 45));
            //Console.WriteLine(SomarVarios(1, 2, 45));

            //TesteArray();
            Console.ReadLine();
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            listaDeIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no indice: {i}: {idade}");
            }
        }

        //Com o argumento params eu não preciso dizer o tamanho exato do Array, posso passar a qtd 
        // que quiser por argmento que ele vai criar dinamicamente de acordo com a qtd de argumentos
        // enviados para o array.
        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;

            foreach(int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

        //Exemplo de criação de array sem limite especifico
        static void CriarArraySemDizerTamanho()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(235, 44565423),
                new ContaCorrente(235, 33529953),
                new ContaCorrente(235, 12331223)
            };

            foreach(ContaCorrente numero in contas)
            {
                Console.WriteLine($"Número da Agência: {numero.Numero}");
            }
        }

        static void TesteArray()
        {
            int[] idades = null;
            idades = new int[3];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;

            Console.WriteLine($"Tamanho do array idades: {idades.Length}");

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];
                Console.WriteLine($"Indice do array idades na posição {indice} tem o valor de: {idades[indice]}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"A média de idades é de: {media}");
        }

        static string GetRandomCpf()
        {
            Random random = new Random();
            int[] arrayCpf = new int[11];
            int multiplicador = 2;
            int digito = 0;

           
            //preencho os 9 primeiros index do array com números randômicos de 0 a 9
            for (int i = 0; i < 9; i++)
            {
                arrayCpf[i] = random.Next(10);
            }

            // Varre o array e imprime todos os index
            //foreach(int num in arrayCpf)
            //{
            //    Console.WriteLine(num);
            //}

            //Calcular o primeiro dígito verificador
            for (int i = 8; i >= 0; i--)
            {
                digito += arrayCpf[i] * multiplicador;
                multiplicador++;
            }
            //Console.WriteLine($"Resultado da soma dos 9 dígitos: {digito_1}");

            //Verificação do primeiro dítigo do CPF
            //Console.WriteLine($"Resto da divisão da soma por 11: {digito_1 % 11}");
            if ((digito % 11) < 2 )
            {
                arrayCpf[9] = 0;
            }
            else
            {
                arrayCpf[9] = (11 - (digito % 11));
            }
            //Console.WriteLine($"Valor do primeiro dígito: {arrayCpf[9]}");

            multiplicador = 2;
            digito = 0;
            //Calcular o segundo digito verificador
            for (int i = 9; i >= 0; i--)
            {
                digito += arrayCpf[i] * multiplicador;
                multiplicador++;
            }
            //Console.WriteLine($"Resultado da soma dos 9 dígitos: {digito_1}");

            //Verificação do primeiro dítigo do CPF
            //Console.WriteLine($"Resto da divisão da soma por 11: {digito_1 % 11}");
            if ((digito % 11) < 2)
            {
                arrayCpf[10] = 0;
            }
            else
            {
                arrayCpf[10] = (11 - (digito % 11));
            }
            //Console.WriteLine($"Valor do primeiro dígito: {arrayCpf[10]}");

            // Varre o array e imprime todos os index
            string cpf = "";
            //string cpfCompleto = "";
            foreach(int num in arrayCpf)
            {
                cpf += num.ToString();
                //Console.Write(num);
            }
            return cpf;
        }

        static string GetRandomCnpj()
        {
            Random random = new Random();
            int[] arrayCnpj = new int[14];
            int multiplicador = 2;
            int digito = 0;
            
            arrayCnpj[8] = 0;
            arrayCnpj[9] = 0;
            arrayCnpj[10] = 0;
            arrayCnpj[11] = 1;


            //preencho os 8 primeiros index do array com números randômicos de 0 a 9
            for (int i = 0; i < 8; i++)
            {
                arrayCnpj[i] = random.Next(10);
            }

            // Varre o array e imprime todos os index
            //foreach(int num in arrayCnpj)
            //{
            //    Console.WriteLine(num);
            //}

            //Calcular o primeiro dígito verificador
            for (int i = 11; i >= 0; i--)
            {
                digito += arrayCnpj[i] * multiplicador;
                multiplicador++;

                if(multiplicador > 9)
                {
                    multiplicador = 2;
                }
            }
            //Console.WriteLine($"Resultado da soma dos 9 dígitos: {digito}");

            //Verificação do primeiro dítigo do CPF
            //Console.WriteLine($"Resto da divisão da soma por 11: {digito_1 % 11}");
            if ((digito % 11) < 2)
            {
                arrayCnpj[12] = 0;
            }
            else
            {
                arrayCnpj[12] = (11 - (digito % 11));
            }
            //Console.WriteLine($"Valor do primeiro dígito: {arrayCnpj[12]}");

            multiplicador = 2;
            digito = 0;
            //Calcular o segundo digito verificador
            for (int i = 12; i >= 0; i--)
            {
                digito += arrayCnpj[i] * multiplicador;
                multiplicador++;

                if (multiplicador > 9)
                {
                    multiplicador = 2;
                }
            }
            //Console.WriteLine($"Resultado da soma dos 13 dígitos: {digito}");

            //Verificação do primeiro dítigo do CPF
            //Console.WriteLine($"Resto da divisão da soma por 11: {digito % 11}");
            if ((digito % 11) < 2)
            {
                arrayCnpj[13] = 0;
            }
            else
            {
                arrayCnpj[13] = (11 - (digito % 11));
            }
            //Console.WriteLine($"Valor do primeiro dígito: {arrayCnpj[13]}");

            // Varre o array e imprime todos os index
            string cpf = "";
            //string cpfCompleto = "";
            foreach (int num in arrayCnpj)
            {
                cpf += num.ToString();
                //Console.Write(num);
            }
            return cpf;
        }

        static string GetRandomAccount()
        {
            Random numRandom = new Random();
            return numRandom.Next(10000000, 99999999).ToString();
        }

    }
}
