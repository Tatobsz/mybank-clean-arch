using ApplicationBusinessRules.OutputPorts;
using EnterpriseBusinessRules;

namespace InterfaceAdapters.Gateways
{
    public class MemoriaComDicionarioContaBancariaDb : ContaBancariaDBPort
    {
        static Dictionary<int, ContaBancaria> contasBancarias = new()
        {
            { 123, new ContaBancaria { Agencia = 123, Numero = 123, NomeProprietario = "Tato", Saldo = 5 } },
            { 456, new ContaBancaria { Agencia = 456, Numero = 456, NomeProprietario = "Gih", Saldo = 10 } }
        };

        public async Task<ContaBancaria?> ObterContaBancaria(int numero, int agencia)
        {
            var contaEncontrada = contasBancarias[numero];
            return await Task.FromResult(contaEncontrada);
        }

        public Task SalvarContaBancaria(ContaBancaria contaBancaria)
        {
            var contasAtualizadas = contasBancarias.Select(conta => conta.Key == contaBancaria.Numero ? contaBancaria : conta.Value)
                .ToDictionary(conta => conta.Numero, conta => conta);

            contasBancarias = contasAtualizadas;
            return Task.CompletedTask;
        }
    }
}
