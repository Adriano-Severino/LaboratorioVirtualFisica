using Application.UseCases;
using Domain.Services;
using Infrastructure.Persistence;
using Presentation.Controllers;

class Program
{
    static void Main(string[] args)
    {
        var physicsService = new PhysicsService();
        var logger = new FileLogger();
        var simulateMovement = new SimulateMovement(physicsService, logger);
        var controller = new SimulationController(simulateMovement);

        controller.Run();
    }
}