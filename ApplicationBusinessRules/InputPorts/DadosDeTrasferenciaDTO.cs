namespace ApplicationBusinessRules.InputPorts
{
    public record DadosDeTrasferenciaDTO(
        DadosDaContaBancariaDTO Origem,
        DadosDaContaBancariaDTO Destino,
        double Valor
    );
}
