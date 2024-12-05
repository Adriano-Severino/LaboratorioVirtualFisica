using Application.UseCases;
using Domain.Services;
using Presentation.Controllers;

class Program
{
    static void Main(string[] args)
    {
        var physicsService = new PhysicsService();
        var simulateMovement = new SimulateMovement(physicsService);
        var controller = new SimulationController(simulateMovement);

        controller.Run();
    }
}