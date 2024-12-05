using Application.UseCases;
using Infrastructure.Persistence;
using LaboratorioVirtualFisica.Domain.Entities;

namespace Presentation.Controllers
{
    public class SimulationController
    {
        private readonly SimulateMovement _simulateMovement;
        private readonly FileLogger _logger;

        public SimulationController(SimulateMovement simulateMovement, FileLogger logger)
        {
            _simulateMovement = simulateMovement;
            _logger = logger;
        }

        public void Run()
        {
            Console.Write("Digite a força aplicada (em Newtons): ");
            double force = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite a massa da partícula (em kg): ");
            double mass = Convert.ToDouble(Console.ReadLine());

            Console.Write("Considerar atrito? (S/N): ");
            bool considerFriction = Console.ReadLine().Trim().ToUpper().StartsWith("S");

            var particle = new Particle(mass, force);

            // Log simulation details
            _logger.LogDetails(considerFriction, force, mass);

            // Lista para armazenar medições de tempo e posição
            var measurements = new List<(double Time, double Position)>();

            foreach (var time in new[] { 1.0, 5.0, 10.0, 15.0, 20.0 })
            {
                // Executa a simulação e registra os resultados
                var position = _simulateMovement.ExecuteAndLog(time, particle, considerFriction);

                // Armazena o tempo e a posição para calcular a velocidade média
                measurements.Add((time, position));
            }

            // Calcula e registra a velocidade média
            double averageVelocity = CalculateAverageVelocity(measurements);
            Console.WriteLine($"Velocidade Média: {averageVelocity:F2}m/s");
            _logger.LogAverageVelocity(averageVelocity);

            // Salva o log no arquivo
            _logger.SaveLog();
        }

        private double CalculateAverageVelocity(List<(double Time, double Position)> measurements)
        {
            if (measurements.Count < 2) return 0;

            var firstMeasurement = measurements[0];
            var lastMeasurement = measurements[^1]; // Último elemento

            double totalTime = lastMeasurement.Time - firstMeasurement.Time;
            double totalDistance = lastMeasurement.Position - firstMeasurement.Position;

            return totalDistance / totalTime;
        }
    }
}