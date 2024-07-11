using ApplicationBusinessRules.InputPorts;
using ApplicationBusinessRules.OutputPorts;
using EnterpriseBusinessRules;

namespace ApplicationBusinessRules.UseCases
{
    public class TransferirValorEntreContasUseCase(ContaBancariaDBPort contaBancariaDBPort)
    {
        public async Task ExcecutarCasoDeUso(DadosDaContaBancariaDTO contaOrigemParam, DadosDaContaBancariaDTO contaDestinoParam, double valor)
        {
            var contaOrigem = await contaBancariaDBPort.ObterContaBancaria(contaOrigemParam.Numero, contaOrigemParam.Agencia);
            var contaDestino = await contaBancariaDBPort.ObterContaBancaria(contaDestinoParam.Numero, contaDestinoParam.Agencia);

            var transferencia = new TransferenciaBancaria();
            var deuCertoATransferencia = transferencia.TranferirEntreContas(contaOrigem, contaDestino, valor);

            if (deuCertoATransferencia)
            {
                await contaBancariaDBPort.SalvarContaBancaria(contaOrigem);
                await contaBancariaDBPort.SalvarContaBancaria(contaDestino);
            }
            else
            {
                throw new Exception("Algo deu errado na transferencia");
            }
        }
    }
}