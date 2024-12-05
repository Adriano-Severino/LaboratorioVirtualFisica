namespace LaboratorioVirtualFisica.Domain.Entities
{
    public class Particle
    {
        public double Mass { get; private set; }
        public double Force { get; private set; }

        public Particle(double mass, double force)
        {
            Mass = mass;
            Force = force;
        }

        public double GetAcceleration() => Force / Mass;
    }
}
