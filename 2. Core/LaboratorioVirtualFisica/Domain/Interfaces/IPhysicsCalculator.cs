using LaboratorioVirtualFisica.Domain.Entities;

namespace Domain.Interfaces
{
    /// <summary>
    /// Interface que define o contrato para um calculador de física.
    /// </summary>
    public interface IPhysicsCalculator
    {
        /// <summary>
        /// Calcula o movimento de uma partícula em um determinado tempo.
        /// </summary>
        /// <param name="time">O tempo decorrido em segundos.</param>
        /// <param name="particle">A partícula cujo movimento será calculado.</param>
        /// <param name="considerFriction">Indica se o atrito deve ser considerado no cálculo.</param>
        /// <returns>Uma tupla contendo a posição (em metros) e a velocidade (em metros por segundo) da partícula após o tempo especificado.</returns>
        (double Position, double Velocity) CalculateMovement(double time, Particle particle, bool considerFriction);
    }
}