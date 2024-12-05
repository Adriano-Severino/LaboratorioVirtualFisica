using Application.UseCases;
using Domain.Services;
using Infrastructure.Persistence;
using Presentation.Controllers;

/// <summary>
/// Classe principal do programa que inicializa e executa a simulação de movimento de partículas.
/// </summary>
class Program
{
    /// <summary>
    /// Ponto de entrada principal do aplicativo.
    /// </summary>
    /// <param name="args">Argumentos da linha de comando (não utilizados nesta aplicação).</param>
    static void Main(string[] args)
    {
        // Inicializa o serviço de física para cálculos de movimento
        var physicsService = new PhysicsService();

        // Inicializa o logger para registro de dados da simulação
        var logger = new FileLogger();

        // Cria o caso de uso para simulação de movimento
        var simulateMovement = new SimulateMovement(physicsService, logger);

        // Inicializa o controlador da simulação
        var controller = new SimulationController(simulateMovement, logger);

        // Executa a simulação
        controller.Run();
    }
}