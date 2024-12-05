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

        Console.WriteLine("Tempo (s)\tPosição (m)\tVelocidade Instantânea (m/s)\tVelocidade Média Total (m/s)");

        // Calcular a velocidade média do intervalo de 1 metro até 500 metros
        double tempoInicial = 0;
        double posicaoInicial = 1;
        double posicaoFinal = 500;
        double velocidadeInicial = 0;

        // Encontrar o tempo que a partícula leva para atingir 500 metros (sem atrito)
        double tempoFinal = Math.Sqrt((2 * (posicaoFinal - posicaoInicial)) / aceleracao);
        if (considerarAtrito)
        {
            // Ajustar o cálculo do tempo considerando o atrito
            tempoFinal = CalcularTempoComAtrito(posicaoInicial, posicaoFinal, aceleracao, constanteAtrito, massa);
        }
        
        double velocidadeFinal = aceleracao * tempoFinal;

        // Calcular a velocidade média total
        double velocidadeMediaTotal = (posicaoFinal - posicaoInicial) / tempoFinal;

        // Mostrar os valores em tempos específicos e a velocidade média total
        MostrarValores(1, aceleracao, constanteAtrito, considerarAtrito, massa);
        MostrarValores(5, aceleracao, constanteAtrito, considerarAtrito, massa);
        MostrarValores(10, aceleracao, constanteAtrito, considerarAtrito, massa);
        MostrarValores(15, aceleracao, constanteAtrito, considerarAtrito, massa);
        MostrarValores(20, aceleracao, constanteAtrito, considerarAtrito, massa);

        Console.WriteLine($"\nVelocidade Média Total de 1m a 500m: {velocidadeMediaTotal:F2} m/s");
    }

    static void MostrarValores(double tempo, double aceleracao, double constanteAtrito, bool considerarAtrito, double massa)
    {
        double posicao = 1 + 0.5 * aceleracao * Math.Pow(tempo, 2);
        double velocidade = aceleracao * tempo;

        if (considerarAtrito)
        {
            // Ajustar os cálculos considerando o atrito
            posicao = CalcularPosicaoComAtrito(tempo, aceleracao, constanteAtrito, massa);
            velocidade = CalcularVelocidadeComAtrito(tempo, aceleracao, constanteAtrito, massa);
        }

        // Limitar a posição a um máximo de 500 metros
        if (posicao > 500)
        {
            posicao = 500;
        }

        Console.WriteLine($"Tempo: {tempo}s - Posição: {Math.Round(posicao)}m - Velocidade Instantânea: {velocidade:F2}m/s");
    }

    static double CalcularTempoComAtrito(double posicaoInicial, double posicaoFinal, double aceleracao, double constanteAtrito, double massa)
    {
        // Simulação aproximada para encontrar o tempo considerando o atrito
        double tempo = 0;
        double intervaloTempo = 0.01; // Pequeno intervalo de tempo para simulação
        double posicao = posicaoInicial;
        double velocidade = 0;
        
        while (posicao < posicaoFinal)
        {
            double forcaAtrito = -constanteAtrito * velocidade;
            double aceleracaoTotal = aceleracao + forcaAtrito / massa;
            velocidade += aceleracaoTotal * intervaloTempo;
            posicao += velocidade * intervaloTempo;
            tempo += intervaloTempo;
        }

        return tempo;
    }

    static double CalcularPosicaoComAtrito(double tempo, double aceleracao, double constanteAtrito, double massa)
    {
        // Simulação aproximada para encontrar a posição considerando o atrito
        double intervaloTempo = 0.01; // Pequeno intervalo de tempo para simulação
        double posicao = 1;
        double velocidade = 0;

        for (double t = 0; t < tempo; t += intervaloTempo)
        {
            double forcaAtrito = -constanteAtrito * velocidade;
            double aceleracaoTotal = aceleracao + forcaAtrito / massa;
            velocidade += aceleracaoTotal * intervaloTempo;
            posicao += velocidade * intervaloTempo;
        }

        return posicao;
    }

    static double CalcularVelocidadeComAtrito(double tempo, double aceleracao, double constanteAtrito, double massa)
    {
        // Simulação aproximada para encontrar a velocidade considerando o atrito
        double intervaloTempo = 0.01; // Pequeno intervalo de tempo para simulação
        double velocidade = 0;

        for (double t = 0; t < tempo; t += intervaloTempo)
        {
            double forcaAtrito = -constanteAtrito * velocidade;
            double aceleracaoTotal = aceleracao + forcaAtrito / massa;
            velocidade += aceleracaoTotal * intervaloTempo;
        }

        return velocidade;
    }
}
