using Domain.Interfaces;
using LaboratorioVirtualFisica.Domain.Entities;
using Infrastructure.Persistence;

namespace Application.UseCases
{
    /// <summary>
    /// Classe responsável por simular o movimento de uma partícula e registrar os resultados.
    /// </summary>
    public class SimulateMovement
    {
        private readonly IPhysicsCalculator _physicsCalculator;
        private readonly FileLogger _logger;

        /// <summary>
        /// Inicializa uma nova instância da classe SimulateMovement.
        /// </summary>
        /// <param name="physicsCalculator">Calculadora de física para realizar os cálculos de movimento.</param>
        /// <param name="logger">Logger para registrar os resultados da simulação.</param>
        public SimulateMovement(IPhysicsCalculator physicsCalculator, FileLogger logger)
        {
            _physicsCalculator = physicsCalculator;
            _logger = logger;
        }

        /// <summary>
        /// Executa a simulação do movimento de uma partícula e registra os resultados.
        /// </summary>
        /// <param name="time">Tempo da simulação em segundos.</param>
        /// <param name="particle">Partícula a ser simulada.</param>
        /// <param name="considerFriction">Indica se o atrito deve ser considerado na simulação.</param>
        /// <returns>A posição final da partícula após a simulação.</returns>
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