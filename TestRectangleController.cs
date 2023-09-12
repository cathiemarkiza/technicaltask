using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class TestRectangleController
{
    private RectangleController controller;

    [SetUp]
    public void Setup()
    {
        // Create an instance of the controller with a mock service or repository
        var service = new MockRectangleService();
        controller = new RectangleController(service);
    }

    [Test]
    public void GetAllRectangles_ReturnsOkResult()
    {
        
        var result = controller.GetAllRectangles();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
    }

    [Test]
    public void GetAllRectangles_ReturnsAllRectangles()
    {
        
        var result = controller.GetAllRectangles().Result as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        var rectangles = result.Value as IEnumerable<Rectangle>;
        Assert.NotNull(rectangles);
        Assert.AreEqual(GetTestRectangles().Count(), rectangles.Count());
    }


    private IEnumerable<Rectangle> GetTestRectangles()
    {
        // Return test data for rectangles
        var rectangles = new List<Rectangle>
        {
            new Rectangle { Id = 1, Length = 5, Width = 10 },
            new Rectangle { Id = 2, Length = 3, Width = 6 },
            new Rectangle { Id = 3, Length = 7, Width = 9 }
        };
        return rectangles;
    }
}
