using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite a força aplicada (em Newtons): ");
        double forca = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite a massa da partícula (em kg): ");
        double massa = Convert.ToDouble(Console.ReadLine());

        double constanteAtrito = 0.1; // constante de atrito
        bool considerarAtrito = true; // modificar para true ou false conforme necessário
        double aceleracao = forca / massa; // aceleracao = F / m

        if (considerarAtrito)
        {
            Console.WriteLine("Com atrito");
        }
        else
        {
            Console.WriteLine("Sem atrito");
        }
        Console.WriteLine($"Força aplicada de: {forca} Newtons");
        Console.WriteLine($"Massa da particula de: {massa} Kgs");
        Console.WriteLine("============================================================");
        Console.WriteLine("Tempo (s)\tPosição (m)\tVelocidade Instantânea (m/s)");

        double posicaoInicial = 0;
        double velocidadeInicial = 0;

        // Mostrar os valores em tempos específicos
        double posicaoFinal = MostrarValores(1, aceleracao, constanteAtrito, considerarAtrito, massa, posicaoInicial, velocidadeInicial);
        posicaoFinal = MostrarValores(5, aceleracao, constanteAtrito, considerarAtrito, massa, posicaoInicial, velocidadeInicial);
        posicaoFinal = MostrarValores(10, aceleracao, constanteAtrito, considerarAtrito, massa, posicaoInicial, velocidadeInicial);
        posicaoFinal = MostrarValores(15, aceleracao, constanteAtrito, considerarAtrito, massa, posicaoInicial, velocidadeInicial);
        posicaoFinal = MostrarValores(20, aceleracao, constanteAtrito, considerarAtrito, massa, posicaoInicial, velocidadeInicial);

        // Calcular a velocidade média total
        double velocidadeMediaTotal = posicaoFinal / 20;

        Console.WriteLine($"\nVelocidade Média Total: {velocidadeMediaTotal:F2} m/s");
    }

    static double MostrarValores(double tempo, double aceleracao, double constanteAtrito, bool considerarAtrito, double massa, double posicaoInicial, double velocidadeInicial)
    {
        double posicao, velocidade;

        if (considerarAtrito)
        {
            (posicao, velocidade) = CalcularMovimentoComAtrito(tempo, aceleracao, constanteAtrito, massa, posicaoInicial, velocidadeInicial);
        }
        else
        {
            posicao = posicaoInicial + velocidadeInicial * tempo + 0.5 * aceleracao * Math.Pow(tempo, 2);
            velocidade = velocidadeInicial + aceleracao * tempo;
        }

        Console.WriteLine($"Tempo: {tempo}s - Posição: {(int)posicao}m - Velocidade Instantânea: {velocidade:F2}m/s");
        return posicao;
    }

    static (double posicao, double velocidade) CalcularMovimentoComAtrito(double tempo, double aceleracao, double constanteAtrito, double massa, double posicaoInicial, double velocidadeInicial)
    {
        double intervaloTempo = 0.01;
        double posicao = posicaoInicial;
        double velocidade = velocidadeInicial;

        for (double t = 0; t < tempo; t += intervaloTempo)
        {
            double forcaAtrito = constanteAtrito * massa * 9.8 * Math.Sign(velocidade);
            double aceleracaoTotal = (massa * aceleracao - forcaAtrito) / massa;
            velocidade += aceleracaoTotal * intervaloTempo;
            posicao += velocidade * intervaloTempo;
        }

        return (posicao, velocidade);
    }
}