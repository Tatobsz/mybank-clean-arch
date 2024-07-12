namespace EnterpriseBusinessRules.Test
{
    public class ContaBancariaTest
    {
        [Fact(DisplayName = "Deve sacar o valor com sucesso quando a conta tiver saldo disponível")]
        public void Sacar_QuandoOValorEstaDisposivel_SacarComSucesso()
        {
            // Arrange
            var saldo = 100;
            var valorSaque = 50;
            var valorDoSaldoAposOSaque = saldo - valorSaque;
            var contaBancaria = new ContaBancaria
            {
                Saldo = saldo,
                Numero = 123,
                Agencia = 123,
                NomeProprietario = "Tato"
            };

            // Act
            contaBancaria.Sacar(valorSaque);

            // Assert            
            Assert.Equal(valorDoSaldoAposOSaque, contaBancaria.Saldo);
        }

        [Fact(DisplayName = "Deve lançar o erro 'saldo insuficiente' quando o valor do saque for maior que o saldo disponível")]
        public void Sacar_QuandoOValorEstaIndisposivel_LancarErroSaldoInsuficiente()
        {
            // Arrange
            var saldo = 100;
            var valorSaque = saldo + 1;
            var valorDoSaldoAposOSaque = saldo - valorSaque;
            var contaBancaria = new ContaBancaria
            {
                Saldo = saldo,
                Numero = 123,
                Agencia = 123,
                NomeProprietario = "Tato"
            };

            // Act e Assert
            Assert.Throws<Exception>(() => contaBancaria.Sacar(valorSaque));
        }
    }
}
