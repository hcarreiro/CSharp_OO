using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }


        // Esta implementação permite que realizamos a comparação com o Equals
        // Se os membros de um objeto são iguais.
        // Já que a comparação de dois objetos comparam apenas suas referências na memória
        // que não são iguais.
        public override bool Equals(object obj)
        {
            //Cliente outroCliente = (Cliente)obj;
            Cliente outroCliente = obj as Cliente;

            if(outroCliente == null)
            {
                return false;
            }

            return CPF == outroCliente.CPF; //podemos comparar apenas o CPF pois ele é como uma chave primária de cliente
        }
    }
}
