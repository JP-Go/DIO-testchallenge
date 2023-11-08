namespace test;

using Calculadora.Service;

public class CalculadoraTestes
{
    private Calculadora _calculadora;

    public CalculadoraTestes()
    {
        _calculadora = new Calculadora();
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 6, 8)]
    [InlineData(2, -6, -4)]
    public void DeveSomarERetornarInteiros(int n1, int n2, int esperado)
    {
        var resultado = _calculadora.Somar(n1, n2);

        Assert.Equal(resultado, esperado);
    }

    [Theory]
    [InlineData(1, 1, 0)]
    [InlineData(2, -6, 8)]
    [InlineData(1, 6, -5)]
    public void DeveSubtrairERetornarInteiros(int n1, int n2, int esperado)
    {
        var resultado = _calculadora.Subtrair(n1, n2);

        Assert.Equal(resultado, esperado);
    }

    [Theory]
    [InlineData(21378, 1, 21378)]
    [InlineData(2, 0, 0)]
    [InlineData(1, 6, 6)]
    [InlineData(-1, 5, -5)]
    public void DeveMultiplicarERetornarInteiros(int n1, int n2, int esperado)
    {
        var resultado = _calculadora.Multiplicar(n1, n2);

        Assert.Equal(resultado, esperado);
    }

    [Theory]
    [InlineData(21378, 1, 21378)]
    [InlineData(2, 2, 1)]
    [InlineData(1, -1, -1)]
    [InlineData(-1, 5, 0)]
    public void DeveDividirERetornarInteiros(int n1, int n2, int esperado)
    {
        var resultado = _calculadora.Dividir(n1, n2);

        Assert.Equal(resultado, esperado);
    }

    [Theory]
    [InlineData(21378)]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(182)]
    public void NaoDeveDividirPorZero(int n1)
    {
        Assert.Throws<DivideByZeroException>(() => _calculadora.Dividir(n1, 0));
    }

    [Fact]
    public void DeveAdicionarNoHistorico()
    {
        int op1 = 1,
            op2 = 2;
        _calculadora.Somar(op1, op2);
        Assert.Equal(1, _calculadora.Historico().Count);
        _calculadora.Somar(op1, op2);
        _calculadora.Subtrair(op1, op2);
        Assert.Equal(3, _calculadora.Historico().Count);
        Assert.All(_calculadora.Historico().Select(x => x[0]), x => x.Equals("s"));
        _calculadora.Multiplicar(op1, op2);
        Assert.Equal("multiplicar: 1,2", _calculadora.Historico()[0]);
    }
}
