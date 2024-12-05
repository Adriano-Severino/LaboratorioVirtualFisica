
using Domain.Services;
using LaboratorioVirtualFisica.Domain.Entities;

public class PhysicsServiceTests
{
    [Theory]
    [InlineData(false, 63, 25.0)] // Sem atrito
    [InlineData(true, 51, 20.1)]  // Com atrito
    public void CalculateMovement_ShouldReturnCorrectValues(bool considerFriction, int expectedPosition, double expectedVelocity)
    {
        // Arrange
        var service = new PhysicsService();
        var particle = new Particle(2, 10); // Massa = 2kg, Força = 10N

        // Act
        var result = service.CalculateMovement(5, particle, considerFriction);

        // Assert
        Assert.InRange(result.Position, expectedPosition - 1, expectedPosition + 1);
        Assert.InRange(result.Velocity, expectedVelocity - 0.5, expectedVelocity + 0.5);
    }
}