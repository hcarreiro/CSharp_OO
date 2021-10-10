using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteBank.SistemaAgencia
{
    class Program
    {


        static void Main(string[] args)
        {
        Console.WriteLine("*/*");
        Console.ReadLine();

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(GetRandom3Numbers() + "." + GetRandom2Numbers());
            }


            //OperadorLinqWhere();

            Console.ReadLine();
        }

        static void OperadorLinqWhere()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(1, 70),
                new ContaCorrente(123, 123321),
                null,
                new ContaCorrente(231, 284811),
                null,
                new ContaCorrente(435, 929399),
                new ContaCorrente(875, 832343)
            };

            ///* Forma mais trabalhosa de fazer sem uso de expressões lambda */
            //var listaSemNulos = new List<ContaCorrente>();
            //foreach(var conta in contas)
            //{
            //    if (conta != null)
            //        listaSemNulos.Add(conta);
            //}

            // Forma mais otimizada utilizando Linq com o operador Where e a expressão lambda
            // o Where retorna sempre um IEnumerable de valores, mesmo que ele encontre apenas 1 valor
            //IEnumerable<ContaCorrente> contasNaoNulas = contas.Where(conta => conta != null);

            //Possível implementação usando list ao invés de IEnumerable
            //List<ContaCorrente> contasNaoNulas = contas.Where(conta => conta != null).ToList();

            // O <IEnumerable, int> é implicito, foi colocado apenas para estudo
            // nova implementação abaixo com tudo junto
            //IOrderedEnumerable<ContaCorrente> contasOrdenadas =
            //    contasNaoNulas.OrderBy<IEnumerable, int>(banana => banana.Numero);

            // Nova implementação utilizando o linq e expressão lambada com where e orderby juntos
            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número: {conta.Numero}, Agência: {conta.Agencia}");
            }
        }

        // Este método retorna um IOrderedEnumerable<T> onde ali teremos
        // uma coleção ordenada de T de acordo com o valor solicitado
        // no nosso exemplo Numero. Este valor poderia ser qualquer um de
        // de T desde que este valor implemente IComparable.
        // a expressão (operador => ) é uma expressão lambda que diz:
        // "Varra toda lista de conta e em cada conta retorne o valor de conta.Numero" 
        // E esse valor retornado será o valor considerado pelo OrderBy para retornar a coleção
        // ordenada.
        static void OrderBy()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(1, 70),
                new ContaCorrente(123, 123321),
                null,
                new ContaCorrente(231, 284811),
                null,
                new ContaCorrente(435, 929399),
                new ContaCorrente(875, 832343)
            };

            //// OrderBy com expressão lambda simples de um valor
            //IOrderedEnumerable<ContaCorrente> contasOrdenadas =
            //    contas.OrderBy(conta => conta.Numero);
            // ou
            //IOrderedEnumerable<ContaCorrente> contasOrdenadas =
            //   contas.OrderBy(conta => { return conta.Numero; });

            // Como o OrderBy não verifica valores Null, ele lança uma exceção
            // caso este valor seja encontrado pela expressão lambda acima e envie
            // para o OrderBy. Para corrigir isso vamos realizar a próxima implementação
            IOrderedEnumerable<ContaCorrente> contasOrdenadas =
                contas.OrderBy(banana => {
                    if(banana == null)
                    {
                        return int.MaxValue;
                    }
                    return banana.Numero;
                });

            foreach(var conta in contasOrdenadas)
            {
                if(conta == null)
                    Console.WriteLine("Conta nula.");
                else
                    Console.WriteLine($"Conta número: {conta.Numero}, Agência: {conta.Agencia}");

                //// Caso não me interesse as contas nulas posso fazer da seguinte forma
                //if(conta != null)
                //    Console.WriteLine($"Conta número: {conta.Numero}, Agência: {conta.Agencia}");

            }
        }

        //Usando o Sort parâmetro genérico e a interface IComparer
        //Assim podemos ter várias tipos de ornação diferentes para o
        //mesmo objeto (ordenar por Conta ou Agência ou Sado etc)
        static void SortObjetoDiverso()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(1, 70),
                new ContaCorrente(123, 123321),
                new ContaCorrente(231, 284811),
                new ContaCorrente(435, 929399),
                new ContaCorrente(875, 832343)
            };

            //Passando um objeto genérico que implementa a interface
            // IComparer
            contas.Sort(new ComparadorContaCorrentePorAgencia());

            foreach (var conta in contas)
            {
                Console.WriteLine($"Conta númro: {conta.Numero}, ag. {conta.Agencia}");
            }
        }

        //Usando o Sort com objeto e a interface IComparable
        static void SortObjeto()
        {
            //Modelo comparação com objeto com vários atributos usando a interface IComparable
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(1, 70),
                new ContaCorrente(123, 123321),
                new ContaCorrente(231, 284811),
                new ContaCorrente(435, 929399),
                new ContaCorrente(875, 832343)
            };

            //Chama a implementação dada em IComparable
            contas.Sort();

            foreach (var conta in contas)
            {
                Console.WriteLine($"Conta númro: {conta.Numero}, ag. {conta.Agencia}");
            }
        }
        
        //Método demonstrativo com ordenação e utilização de métodos genéricos
        static void Ordenacao()
        {
            var nomes = new List<string>();
            nomes.AdicionarVarios("Adoniram", "Jimi Hendrix", "Ana Paula", "Flavio", "Bruce");

            nomes.Sort();

            foreach (var item in nomes)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");


            var idades = new List<int>();
            idades.AdicionarVarios(1, 61, 14, 38, 25, 5);

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }
            Console.WriteLine("\n");

            idades.Sort();

            idades.Remove(5);

            foreach (var item in idades)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
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

        static string GetRandom3Numbers()
        {
            Random numRandom = new Random();
            return numRandom.Next(100, 999).ToString();
        }
        static string GetRandom2Numbers()
        {
            Random numRandom = new Random();
            return numRandom.Next(10, 99).ToString();
        }

        static void GetRandomPersonOrJuridic()
        {
            Random numRandom = new Random();
            int option = numRandom.Next(0, 2);

            if (option == 0)
            {
                Console.WriteLine($"Random: {option} / Física");
            }
            else
                Console.WriteLine($"Random: {option} / Jurídica");
        }

        static string GetRandomPersonOrJuridic2()
        {
            Random _random = new Random();
            string type = "JF";
            return new String(Enumerable.Repeat(type, 1)
                .Select(s => s[_random.Next(s.Length)])
               .ToArray());
               
        }
    }
}
