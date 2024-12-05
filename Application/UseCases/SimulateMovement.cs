using Domain.Interfaces;
using LaboratorioVirtualFisica.Domain.Entities;
using Infrastructure.Persistence;

namespace Application.UseCases
{
    public class SimulateMovement
    {
        private readonly IPhysicsCalculator _physicsCalculator;
        private readonly FileLogger _logger;

        public SimulateMovement(IPhysicsCalculator physicsCalculator, FileLogger logger)
        {
            _physicsCalculator = physicsCalculator;
            _logger = logger;
        }

        public void Execute(double time, Particle particle, bool considerFriction)
        {
            // Log the friction condition, force, and mass
            _logger.LogDetails(considerFriction, particle.Force, particle.Mass);

            // Perform calculations
            var (position, velocity) = _physicsCalculator.CalculateMovement(time, particle, considerFriction);

            // Log the result
            string message = $"Tempo: {time}s - Posição: {position:F2}m - Velocidade: {velocity:F2}m/s";
            _logger.Log(message);
            Console.WriteLine(message);
        }
    }
}