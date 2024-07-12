using EnterpriseBusinessRules;

namespace ApplicationBusinessRules.OutputPorts
{
    public interface ContaBancariaDBPort
    {
        Task SalvarContaBancaria(ContaBancaria contaBancaria);
        Task<ContaBancaria?> ObterContaBancaria(int numero, int agencia);
    }
}