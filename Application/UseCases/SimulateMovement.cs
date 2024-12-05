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

        public double ExecuteAndLog(double time, Particle particle, bool considerFriction)
        {
            var (position, velocity) = _physicsCalculator.CalculateMovement(time, particle, considerFriction);

            // Log calculation details
            _logger.LogCalculation(time, position, velocity);

            Console.WriteLine($"Tempo: {time}s - Posição: {position:F2}m - Velocidade: {velocity:F2}m/s");

            return position;
        }
    }
}