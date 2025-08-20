using HackathonMonolito.Models.Enums;
using HackathonMonolito.Services;
using Xunit.Abstractions;

namespace TestProject1;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        var calculator = new CalculadoraSAC();
        
        var resultado = calculator.Calcular(900, 0.0179m,5);

        Assert.NotNull(resultado);
        Assert.Equal(5, resultado.Parcelas.Count);
        Assert.Equal(SistemaAmortizacao.PRICE, resultado.Tipo);
    }
}