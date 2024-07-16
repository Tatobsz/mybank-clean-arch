using ApplicationBusinessRules.InputPorts;
using ApplicationBusinessRules.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace MyBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferenciaController : ControllerBase
    {
        public readonly TransferirValorEntreContasUseCase transferirValorEntreContasUseCase;

        public TransferenciaController(TransferirValorEntreContasUseCase transferirValorEntreContasUseCase)
        {
            this.transferirValorEntreContasUseCase = transferirValorEntreContasUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Transferir([FromBody] DadosDeTrasferenciaDTO dadosDaTransferencia)
        {
            try
            {
                await transferirValorEntreContasUseCase.ExcecutarCasoDeUso(
                    dadosDaTransferencia.Origem, dadosDaTransferencia.Destino, dadosDaTransferencia.Valor
                );
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}