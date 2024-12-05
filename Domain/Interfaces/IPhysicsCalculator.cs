using LaboratorioVirtualFisica.Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPhysicsCalculator
    {
        (double Position, double Velocity) CalculateMovement(double time, Particle particle);
    }
}