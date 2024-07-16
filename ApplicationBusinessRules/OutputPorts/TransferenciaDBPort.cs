using EnterpriseBusinessRules;

namespace ApplicationBusinessRules.OutputPorts
{

    public interface TransferenciaDBPort : DBPort<TransferenciaBancaria>
    {
        IEnumerable<TransferenciaBancaria> BuscarDepoisDe(DateTime data);
    }
}