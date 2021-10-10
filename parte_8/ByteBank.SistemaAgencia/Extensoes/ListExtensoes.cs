
using System.Collections.Generic;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        //Método genérico que pode receber qualquer tipo para o list
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            foreach (T intem in itens)
            {
                lista.Add(intem);
            }
        }
    }
}
