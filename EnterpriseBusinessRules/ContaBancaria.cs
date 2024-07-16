namespace EnterpriseBusinessRules
{
    public class ContaBancaria
    {
        public int Numero { get; set; }
        public string NomeProprietario { get; set; } = String.Empty;
        public double Saldo { get; set; }
        public int Agencia { get; set; }

        public virtual void Sacar(double valor)
        {
            var novoSaldo = Saldo - valor;

            if (novoSaldo < 0)
            {
                throw new Exception("Saldo insuficiente");
            }

            Saldo -= valor;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }
    }
}
