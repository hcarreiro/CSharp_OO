namespace _05_ByteBank
{
    public class ContaCorrente
    {
        public Cliente cliente;
        public int agencia;
        public int conta;
        public double saldo = 100;

        public bool Sacar(double valor)
        {
            if (this.saldo < valor)
            {
                return false;
            }
            else
            {
                this.saldo -= valor;
                return true;
            }
        }

        public void Depositar(double valor)
        {
            this.saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (this.saldo < valor)
            {
                return false;
            }

            // Poderíamos ter o else ou não. Não temos porque já temos o returno no if, ou seja se entrar no if ele sai da função
            // e se ele não entrar no if executa a instrução abaixo.
            this.saldo -= valor;
            contaDestino.Depositar(valor);
            return true;

        }
    }
}