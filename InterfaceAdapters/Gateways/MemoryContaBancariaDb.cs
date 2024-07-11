using ApplicationBusinessRules.OutputPorts;
using EnterpriseBusinessRules;

namespace InterfaceAdapters.Gateways
{
    public class MemoryContaBancariaDb : ContaBancariaDBPort
    {
        static List<ContaBancaria> contasBancarias = new()
        {
            new ContaBancaria
            {
                Agencia = 123,
                Numero = 123,
                NomeProprietario = "Tato",
                Saldo = 5
            },
            new ContaBancaria
            {
                Agencia = 456,
                Numero = 456,
                NomeProprietario = "Gih",
                Saldo = 10
            }
        };

        public async Task<ContaBancaria?> ObterContaBancaria(int numero, int agencia)
        {
            var contaEncontrada = contasBancarias.Where(conta => conta.Numero == numero && conta.Agencia == agencia).FirstOrDefault();
            return await Task.FromResult(contaEncontrada);
        }

        public Task SalvarContaBancaria(ContaBancaria contaBancaria)
        {
            var contasAtualizadas =
                contasBancarias.Select(conta => conta.Numero == contaBancaria.Numero && conta.Agencia == contaBancaria.Agencia ? contaBancaria : conta)
                .ToList();

            contasBancarias = contasAtualizadas;
            return Task.CompletedTask;
        }
    }
}