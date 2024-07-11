namespace EnterpriseBusinessRules
{
    public class TransferenciaBancaria
    {
        public bool TranferirEntreContas(ContaBancaria contaOrigem, ContaBancaria contaDestino, double valor)
        {
            try
            {
                contaOrigem.Sacar(valor);
                contaDestino.Depositar(valor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}