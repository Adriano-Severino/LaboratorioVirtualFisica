using Domain.Interfaces;
using LaboratorioVirtualFisica.Domain.Entities;

namespace Domain.Services
{
    /// <summary>
    /// Serviço que implementa cálculos físicos para o movimento de partículas.
    /// </summary>
    public class PhysicsService : IPhysicsCalculator
    {
        /// <summary>
        /// Intervalo de tempo usado nos cálculos, em segundos.
        /// </summary>
        private const double Interval = 0.01;

        /// <summary>
        /// Coeficiente de atrito usado nos cálculos quando o atrito é considerado.
        /// </summary>
        private const double FrictionCoefficient = 0.1;

        /// <summary>
        /// Aceleração da gravidade, em m/s².
        /// </summary>
        private const double Gravity = 9.8;

        /// <summary>
        /// Calcula o movimento de uma partícula ao longo do tempo.
        /// </summary>
        /// <param name="time">Tempo total da simulação, em segundos.</param>
        /// <param name="particle">A partícula cujo movimento será calculado.</param>
        /// <param name="considerFriction">Indica se o atrito deve ser considerado nos cálculos.</param>
        /// <returns>Uma tupla contendo a posição final (em metros) e a velocidade final (em m/s) da partícula.</returns>
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