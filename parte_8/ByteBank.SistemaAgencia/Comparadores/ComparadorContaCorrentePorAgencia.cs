using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparadores
{
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            // Se x e y forem null são equivalentes e retonro zero
            // Valido eles primeiro para otimizar as consultas.
            if (x == y)
                return 0;

            //Se x for null quero que ele fique no final retorno positivo
            if (x == null)
                return 1;

            //Se y for null quero x fique na frente retono negativo
            if (y == null)
                return -1;

            /*Podemso usar a implementação seguinte no lugar dos ifs abaixo porque o tipo
             que vamos comparar também implementa a inteface IComparable, e assim ele
             então possui o método CompareTo implementado. Assim podemos apenas então
             chamar o método CompareTo do tipo e passar os valores como argumento que ele 
             se encarrega de analisar e dar o return devido se -1, 0 ou 1 de acordo com os
             valores recebidos*/
            return x.Agencia.CompareTo(y.Agencia);



            //Se agência de x for menor que agência de y, x tem precedência retorno -1
            // x fica na frente de y
            if (x.Agencia < y.Agencia)
                return -1;

            //Se agência de x e agência de y forem iguais, não há precedência retorno 0
            // são equivalentes
            if (x.Agencia == y.Agencia)
                return 0;

            //Se agência de x for maior que agência de y, y tem precedência retorno 1
            // Não tenho if porque já estou validando as duas opções acima então agora
            // só pode ser x.Agencia > y.Agencia
            // y fica na frente de x
            return 1; 
        }
    }
}
