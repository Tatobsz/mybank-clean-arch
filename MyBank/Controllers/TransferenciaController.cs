using ApplicationBusinessRules.InputPorts;
using ApplicationBusinessRules.UseCases;
using InterfaceAdapters.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace MyBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferenciaController : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> Transferir([FromBody] DadosDeTrasferenciaDTO dadosDaTransferencia)
        {
            try
            {
                var dbEmMemoria = new MemoryContaBancariaDb();
                var dbEmMemoriaComDicionario = new MemoriaComDicionarioContaBancariaDb();

                var useCase = new TransferirValorEntreContasUseCase(dbEmMemoriaComDicionario);

                await useCase.ExcecutarCasoDeUso(dadosDaTransferencia.Origem, dadosDaTransferencia.Destino, dadosDaTransferencia.Valor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}