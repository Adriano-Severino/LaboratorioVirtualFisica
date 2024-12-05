using Application.UseCases;
using LaboratorioVirtualFisica.Domain.Entities;

namespace Presentation.Controllers
{
    public class SimulationController
    {
        private readonly SimulateMovement _simulateMovement;

        public SimulationController(SimulateMovement simulateMovement)
        {
            _simulateMovement = simulateMovement;
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

            Console.WriteLine(considerFriction ? "Com atrito" : "Sem atrito");
            Console.WriteLine($"Força aplicada: {force} Newtons");
            Console.WriteLine($"Massa da partícula: {mass} kg");
            Console.WriteLine("============================================================");
            Console.WriteLine("Tempo (s)\tPosição (m)\tVelocidade Instantânea (m/s)");

            foreach (var time in new[] { 1.0, 5.0, 10.0, 15.0, 20.0 })
            {
                _simulateMovement.Execute(time, particle, considerFriction);
            }
        }
    }
}