using Domain.Services;
using LaboratorioVirtualFisica.Domain.Entities;

/// <summary>
/// Classe de testes para o PhysicsService.
/// </summary>
public class PhysicsServiceTests
{
    /// <summary>
    /// Testa se o método CalculateMovement retorna valores corretos para diferentes cenários.
    /// </summary>
    /// <param name="considerFriction">Indica se o atrito deve ser considerado no cálculo.</param>
    /// <param name="expectedPosition">A posição esperada após o cálculo, com uma margem de erro de ±1 metro.</param>
    /// <param name="expectedVelocity">A velocidade esperada após o cálculo, com uma margem de erro de ±0.5 m/s.</param>
    [Theory]
    [InlineData(false, 63, 25.0)] // Cenário sem atrito
    [InlineData(true, 51, 20.1)]  // Cenário com atrito
    public void CalculateMovement_ShouldReturnCorrectValues(bool considerFriction, int expectedPosition, double expectedVelocity)
    {
        // Arrange
        var service = new PhysicsService();
        var particle = new Particle(2, 10); // Partícula com massa de 2kg e força aplicada de 10N

        // Act
        var result = service.CalculateMovement(5, particle, considerFriction);

        // Assert
        Assert.InRange(result.Position, expectedPosition - 1, expectedPosition + 1);
        Assert.InRange(result.Velocity, expectedVelocity - 0.5, expectedVelocity + 0.5);
    }
}