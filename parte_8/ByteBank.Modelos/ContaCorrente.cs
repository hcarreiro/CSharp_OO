using System;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Define uma Conta Corrente do banco ByteBank.
    /// </summary>
    public class ContaCorrente : IComparable
    {
        private static int TaxaOperacao;

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia"> Representa o valor da propriedade <see cref="Agencia"/> e deve possuir um valor maior que zero. </param>
        /// <param name="numero"> Representa o valor da propriedade <see cref="Numero"/> e deve possuir um valor maior que zero. </param>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <exception cref="ArgumentException"> Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>. </exception>
        /// <exception cref="SaldoInsuficienteException"> Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/>. </exception>
        /// <param name="valor"> Representa o valor do saque, deve ser maior que 0 e menor que o <see cref="Saldo"/>. </param>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }

        //realizando override do método Equals para ele comparar o número e a agencia do objeto ContaCorrente
        //referenciado.
        public override bool Equals(object obj)
        {
            //A vantagem de usar o as no lugar o casting é que se o valor não for compatível a variável que
            // recebe fica com o valor null
            ContaCorrente outraConta = obj as ContaCorrente;

            if(outraConta == null)
            {
                return false;
            }
            return (Numero == outraConta.Numero && Agencia == outraConta.Agencia);
        }

        public int CompareTo(object obj)
        {
            // Retornar negativo quando a instância precede o obj
            // Retornar zero quando a instância e obj forem equivalentes
            // Retorna positivo diferente de zero quando a precedência for de obj

            // Uso o 'as' para fazer uma conversão "segura" de obj para ContaCorrente
            var outraConta = obj as ContaCorrente;


            /*Podemso usar a implementação abaixo no lugar dos ifs abaixo porque o tipo
             que vamos comparar também implementa a inteface IComparable, e assim ele
             então possuir o método CompareTo implementado. Assim podemos apenas então
             chamar o método CompareTo do tipo e passar os valores como argumento que ele 
             se encarrega de analisar e dar o return devido se -1, 0 ou 1 de acordo com os
             valores recebidos*/
            return Numero.CompareTo(outraConta.Numero);

            //Tratamento para o caso de um falha na conversão do Object para ContaCorrent
            //onde o valor padrão é null - No caso referência nula fica no final da lista.
            if(outraConta == null)
            {
                return -1;
            }
            //Se o número da instância for menor que o número da outraConta
            if(Numero < outraConta.Numero)
            {
                return -1;
            }
            //Se o número da instância for igual que o número da outraConta
            if (Numero == outraConta.Numero)
            {
                return 0;
            }
            //Se o número da instância for maior que o número da outraConta
            return 1;
        }
    }
}
