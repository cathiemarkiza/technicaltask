using NUnit.Framework;
using System.Linq;

[TestFixture]
public class TestRectangleRepository
{
    private IRectangleRepository repository;

    [SetUp]
    public void Setup()
    {
        // Create an instance of the repository or use a mock implementation
        repository = new RectangleRepository();
    }

    [Test]
    public void GetAllRectangles_ReturnsEmptyList()
    {
        
        var rectangles = repository.GetAllRectangles();

        // Assert
        Assert.NotNull(rectangles);
        Assert.IsEmpty(rectangles);
    }

    [Test]
    public void AddRectangle_AddsNewRectangle()
    {
        
        var rectangle = new Rectangle { Id = 1, Length = 5, Width = 10 };

        repository.AddRectangle(rectangle);
        var rectangles = repository.GetAllRectangles();

        // Assert
        Assert.NotNull(rectangles);
        Assert.AreEqual(1, rectangles.Count());
        Assert.AreEqual(rectangle, rectangles.First());
    }
}
