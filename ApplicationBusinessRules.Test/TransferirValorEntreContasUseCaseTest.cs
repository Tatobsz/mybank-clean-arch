using ApplicationBusinessRules.InputPorts;
using ApplicationBusinessRules.OutputPorts;
using ApplicationBusinessRules.UseCases;
using EnterpriseBusinessRules;
using Moq;

namespace ApplicationBusinessRules.Test
{

    public class TransferirValorEntreContasUseCaseTest
    {
        [Fact(DisplayName = "Deve atualizar o saldo das contas quando a transferência acontecer com sucesso")]
        public async Task ExcecutarCasoDeUso_QuandoATransferenciaAcontecerComSucess_AtualizarOsSaldosDasContas()
        {
            // Arrange
            var contaOrigem = new ContaBancaria
            {
                Agencia = 123,
                Numero = 123,
                NomeProprietario = "Tato",
                Saldo = 100
            };

            var contaDestino = new ContaBancaria
            {
                Agencia = 456,
                Numero = 456,
                NomeProprietario = "Gih",
                Saldo = 100
            };

            var mockDbEmMemoria = new Mock<ContaBancariaDBPort>();

            mockDbEmMemoria.Setup(db => db.ObterContaBancaria(contaOrigem.Numero, contaOrigem.Agencia))
                .ReturnsAsync(() =>
                {
                    return contaOrigem;
                });

            mockDbEmMemoria.Setup(db => db.ObterContaBancaria(contaDestino.Numero, contaDestino.Agencia))
                .ReturnsAsync(() =>
                {
                    return contaDestino;
                });

            var valorDaTransferencia = 50;
            var valorEsperadoOrigem = contaOrigem.Saldo - valorDaTransferencia;
            var valorEsperadoDestino = contaDestino.Saldo + valorDaTransferencia;

            var useCase = new TransferirValorEntreContasUseCase(
                mockDbEmMemoria.Object
            );

            // Act
            await useCase.ExcecutarCasoDeUso(
                new DadosDaContaBancariaDTO(Numero: 123, Agencia: 123),
                new DadosDaContaBancariaDTO(Numero: 456, Agencia: 456),
                valorDaTransferencia
            );

            // Assert
            mockDbEmMemoria.Verify(db => db.SalvarContaBancaria(It.Is<ContaBancaria>(conta => conta.Saldo == valorEsperadoOrigem)), Times.Once);
            mockDbEmMemoria.Verify(db => db.SalvarContaBancaria(It.Is<ContaBancaria>(conta => conta.Saldo == valorEsperadoDestino)), Times.Once);
        }
    }
}