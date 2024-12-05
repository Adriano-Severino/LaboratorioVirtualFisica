using System;

class Program
{
    static void Main(string[] args)
    {
        var simulador = new SimuladorMovimento(new ConsoleIO());
        simulador.ExecutarSimulacao();
    }
}

public class SimuladorMovimento
{
    private readonly IIO _io;
    private readonly CalculadorMovimento _calculador;

    public SimuladorMovimento(IIO io)
    {
        _io = io;
        _calculador = new CalculadorMovimento();
    }

    public void ExecutarSimulacao()
    {
        var parametros = ObterParametrosEntrada();
        MostrarConfiguracaoSimulacao(parametros);
        ExecutarEMostrarResultados(parametros);
    }

    private ParametrosSimulacao ObterParametrosEntrada()
    {
        double forca = _io.LerDouble("Digite a força aplicada (em Newtons): ");
        double massa = _io.LerDouble("Digite a massa da partícula (em kg): ");
        return new ParametrosSimulacao(forca, massa);
    }

    private void MostrarConfiguracaoSimulacao(ParametrosSimulacao parametros)
    {
        _io.Escrever(parametros.ConsiderarAtrito ? "Com atrito" : "Sem atrito");
        _io.Escrever($"Força aplicada de: {parametros.Forca} Newtons");
        _io.Escrever($"Massa da particula de: {parametros.Massa} Kgs");
        _io.Escrever("============================================================");
        _io.Escrever("Tempo (s)\tPosição (m)\tVelocidade Instantânea (m/s)");
    }

    private void ExecutarEMostrarResultados(ParametrosSimulacao parametros)
    {
        double posicaoFinal = 0;
        int[] tempos = { 1, 5, 10, 15, 20 };

        foreach (int tempo in tempos)
        {
            var resultado = _calculador.CalcularMovimento(tempo, parametros);
            MostrarResultado(tempo, resultado);
            posicaoFinal = resultado.Posicao;
        }

        double velocidadeMediaTotal = posicaoFinal / 20;
        _io.Escrever($"\nVelocidade Média Total: {velocidadeMediaTotal:F2} m/s");
    }

    private void MostrarResultado(int tempo, ResultadoMovimento resultado)
    {
        _io.Escrever($"Tempo: {tempo}s - Posição: {(int)resultado.Posicao}m - Velocidade Instantânea: {resultado.Velocidade:F2}m/s");
    }
}

public class CalculadorMovimento
{
    private const double IntervaloTempo = 0.01;
    private const double Gravidade = 9.8;

    public ResultadoMovimento CalcularMovimento(double tempo, ParametrosSimulacao parametros)
    {
        if (parametros.ConsiderarAtrito)
        {
            return CalcularMovimentoComAtrito(tempo, parametros);
        }
        return CalcularMovimentoSemAtrito(tempo, parametros);
    }

    private ResultadoMovimento CalcularMovimentoSemAtrito(double tempo, ParametrosSimulacao parametros)
    {
        double aceleracao = parametros.Forca / parametros.Massa;
        double posicao = 0.5 * aceleracao * Math.Pow(tempo, 2);
        double velocidade = aceleracao * tempo;
        return new ResultadoMovimento(posicao, velocidade);
    }

    private ResultadoMovimento CalcularMovimentoComAtrito(double tempo, ParametrosSimulacao parametros)
    {
        double posicao = 0;
        double velocidade = 0;

        for (double t = 0; t < tempo; t += IntervaloTempo)
        {
            double forcaAtrito = parametros.ConstanteAtrito * parametros.Massa * Gravidade * Math.Sign(velocidade);
            double aceleracaoTotal = (parametros.Forca - forcaAtrito) / parametros.Massa;
            velocidade += aceleracaoTotal * IntervaloTempo;
            posicao += velocidade * IntervaloTempo;
        }

        return new ResultadoMovimento(posicao, velocidade);
    }
}

public record ParametrosSimulacao(double Forca, double Massa, double ConstanteAtrito = 0.1, bool ConsiderarAtrito = true)
{
    public double Aceleracao => Forca / Massa;
}

public record ResultadoMovimento(double Posicao, double Velocidade);

public interface IIO
{
    double LerDouble(string mensagem);
    void Escrever(string mensagem);
}

public class ConsoleIO : IIO
{
    public double LerDouble(string mensagem)
    {
        Console.Write(mensagem);
        return Convert.ToDouble(Console.ReadLine());
    }

    public void Escrever(string mensagem)
    {
        Console.WriteLine(mensagem);
    }
}