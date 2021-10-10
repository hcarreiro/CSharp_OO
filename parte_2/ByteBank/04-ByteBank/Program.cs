using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDoBruno = new ContaCorrente();

            contaDoBruno.titular = "Bruno";

            Console.WriteLine($"Saldo R${contaDoBruno.saldo}");
            bool resultadoSaque = contaDoBruno.Sacar(50);
            Console.WriteLine("Saldo R${0}", contaDoBruno.saldo);
            Console.WriteLine(resultadoSaque);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();


            Console.WriteLine($"Saldo R${contaDoBruno.saldo}");
            resultadoSaque = contaDoBruno.Sacar(500);
            Console.WriteLine("Saldo R${0}", contaDoBruno.saldo);
            Console.WriteLine(resultadoSaque);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Saldo R$:{0}", contaDoBruno.saldo);
            contaDoBruno.Depositar(500);
            Console.WriteLine($"Saldo R$:{contaDoBruno.saldo}");

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();

            ContaCorrente contaDaGabriela = new ContaCorrente();
            contaDaGabriela.titular = "Gabriela";

            Console.WriteLine($"Saldo conta {contaDoBruno.titular}: R${contaDoBruno.saldo:F2}");
            Console.WriteLine("Saldo conta {0}: R${1:F2}", contaDaGabriela.titular, contaDaGabriela.saldo);

            bool resultadoTransferencia = contaDoBruno.Transferir(200, contaDaGabriela);

            Console.WriteLine($"Saldo conta {contaDoBruno.titular}: R${contaDoBruno.saldo:F2}");
            Console.WriteLine("Saldo conta {0}: R${1:F2}", contaDaGabriela.titular, contaDaGabriela.saldo);

            Console.WriteLine("Resultado da Transferência: " + resultadoTransferencia);

            Console.ReadLine();
        }
    }
}
