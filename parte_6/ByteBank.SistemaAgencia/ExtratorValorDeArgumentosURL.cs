using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;
        public string URL { get; }

        public ExtratorValorDeArgumentosURL(string url)
        {

            if (String.IsNullOrEmpty(url)) 
            {
                throw new ArgumentException("O argumento url não pode ser uma string nula ou vazia.", nameof(url));
            }

            int indexInterrogacao = url.IndexOf('?');
            //http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500 = 30

            _argumentos = url.Substring(indexInterrogacao + 1);
            //30 + 1
            //valor de _argumentos: moedaOrigem=real&moedaDestino=dolar

            URL = url;
        }

        public string GetValor(string nomeParametro)
        {
            nomeParametro = nomeParametro.ToUpper();
            string argumentoEmCaixaAlta = _argumentos.ToUpper();

            string termo = $"{nomeParametro}=";
            //moedaOrigem=

            int indiceTermo = argumentoEmCaixaAlta.IndexOf(termo);
            //moedaOrigem=real&moedaDestino=dolar pegar o index do início do termo = 0

            string resultado = _argumentos.Substring(indiceTermo + termo.Length);
            //indice início termo: 0
            //termo.Length = 11
            //pega o texto a partir do index 11 = real&moedaDestino=dolar

            int indiceEComercial = resultado.IndexOf('&');
            //indice do & comercial = 4

            if(indiceEComercial == -1)
            {
                //quando o index não é encontrado o IndexOf retorna -1
                //seria o caso de pedirmos para ele buscar o último parametro
                return resultado; 
            }
            return resultado.Remove(indiceEComercial);
            //remover o conteúdo de resultado = real&moedaDestino=dolar
            //remover o conteúdo a partir do index 4 = real
        }
    }
}
