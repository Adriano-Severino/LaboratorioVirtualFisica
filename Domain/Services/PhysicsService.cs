using Domain.Interfaces;
using LaboratorioVirtualFisica.Domain.Entities;

namespace Domain.Services
{
    public class PhysicsService : IPhysicsCalculator
    {
        private const double Interval = 0.01;

        public (double Position, double Velocity) CalculateMovement(double time, Particle particle)
        {
            double position = 0;
            double velocity = 0;
            double acceleration = particle.GetAcceleration();

            for (double t = 0; t < time; t += Interval)
            {
                velocity += acceleration * Interval;
                position += velocity * Interval;
            }

            return (position, velocity);
        }
    }
}