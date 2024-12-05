namespace LaboratorioVirtualFisica.Domain.Entities
{
    /// <summary>
    /// Representa uma partícula com massa e força aplicada.
    /// </summary>
    public class Particle
    {
        /// <summary>
        /// Obtém a massa da partícula em quilogramas.
        /// </summary>
        public double Mass { get; private set; }

        /// <summary>
        /// Obtém a força aplicada à partícula em Newtons.
        /// </summary>
        public double Force { get; private set; }

        /// <summary>
        /// Inicializa uma nova instância da classe Particle.
        /// </summary>
        /// <param name="mass">A massa da partícula em quilogramas.</param>
        /// <param name="force">A força aplicada à partícula em Newtons.</param>
        public Particle(double mass, double force)
        {
            Mass = mass;
            Force = force;
        }

        /// <summary>
        /// Calcula a aceleração da partícula com base na força aplicada e na massa.
        /// </summary>
        /// <returns>A aceleração da partícula em metros por segundo ao quadrado.</returns>
        public double GetAcceleration() => Force / Mass;
    }
}