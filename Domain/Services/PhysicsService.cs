using Domain.Interfaces;
using LaboratorioVirtualFisica.Domain.Entities;

namespace Domain.Services
{
    public class PhysicsService : IPhysicsCalculator
    {
        private const double Interval = 0.01;
        private const double FrictionCoefficient = 0.1;
        private const double Gravity = 9.8;

        public (double Position, double Velocity) CalculateMovement(double time, Particle particle, bool considerFriction)
        {
            double position = 0;
            double velocity = 0;
            double acceleration = particle.GetAcceleration();

            for (double t = 0; t < time; t += Interval)
            {
                if (considerFriction)
                {
                    double frictionForce = FrictionCoefficient * particle.Mass * Gravity * Math.Sign(velocity);
                    acceleration = (particle.Force - frictionForce) / particle.Mass;
                }

                velocity += acceleration * Interval;
                position += velocity * Interval;
            }

            return (position, velocity);
        }
    }
}