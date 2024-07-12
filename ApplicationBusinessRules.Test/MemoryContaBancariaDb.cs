using ApplicationBusinessRules.OutputPorts;
using EnterpriseBusinessRules;

namespace ApplicationBusinessRules.Test
{
    public class MemoryContaBancariaDb : ContaBancariaDBPort
    {
        public static List<ContaBancaria> contasBancarias =
        [
            new ContaBancaria
            {
                Agencia = 123,
                Numero = 123,
                NomeProprietario = "Tato",
                Saldo = 100
            },
            new ContaBancaria
            {
                Agencia = 456,
                Numero = 456,
                NomeProprietario = "Gih",
                Saldo = 100
            }
        ];

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