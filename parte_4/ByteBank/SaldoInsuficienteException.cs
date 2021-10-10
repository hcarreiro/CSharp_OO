using System;

namespace ByteBank
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        // Criadas estas propriedades para serem acessadas/consultadas pelo objeto SaldoInsuficienteException
        public double Saldo { get; }
        public double ValorSaque { get; }

        public SaldoInsuficienteException()
        {
        }

        // Este construtor com o argumento string message permite que seja passado uma mensagem no lançamento desta
        // exceção e repassa para a classe pai (base) exception que já possui a lógica para tratar este argumento.
        // Por isso não há necessidade de implementar nada neste construtor.
        public SaldoInsuficienteException(string message) : base(message)
        {
        }

        // Neste caso estamos gerando um constutor particular para atender nossa necessidade de enviar uma informação 
        // mais completa. Recebemos por parâmetro o saldo e o valor do saque e com o 'this' passando uma string,
        // estamos invocando o construtor desta mesma classe passando a string para ele.
        // Não estamos chamando direto a 'base' porque se fizermos alguma implementação futuramente no nosso construtor
        // com o 'this' ela estará contemplada, se chamarmos a 'base' vamos ter que colocar essa lógica aqui antes de 
        // chamar a 'base'.
        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this($"Tentativa de saque no valor de: {valorSaque} em uma conta com saldo de: {saldo}")
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }

        // Atualmente não temos utilização para este construtor mas por questões de BOA PRÁTICA deixamos ele definido
        // por ser um dos construtores padrão da classe Exception.
        public SaldoInsuficienteException(string mensagem, Exception ie)
            : base (mensagem, ie)
        {
        }
    }
}
