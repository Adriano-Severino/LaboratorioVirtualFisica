using Domain.Interfaces;
using LaboratorioVirtualFisica.Domain.Entities;

namespace Application.UseCases
{
    public class SimulateMovement
    {
        private readonly IPhysicsCalculator _physicsCalculator;

        public SimulateMovement(IPhysicsCalculator physicsCalculator)
        {
            _physicsCalculator = physicsCalculator;
        }

        public void Execute(double time, Particle particle, bool considerFriction)
        {
            var (position, velocity) = _physicsCalculator.CalculateMovement(time, particle, considerFriction);
            Console.WriteLine($"Time: {time}s - Position: {position:F2}m - Velocity: {velocity:F2}m/s");
        }
    }
}