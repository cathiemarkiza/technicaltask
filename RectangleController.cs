using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/rectangles")]
public class RectangleController : ControllerBase
{
    private readonly IRectangleService rectangleService;

    public RectangleController(IRectangleService rectangleService)
    {
        this.rectangleService = rectangleService;
    }

    [HttpGet]
    public IActionResult GetAllRectangles()
    {
        var rectangles = rectangleService.GetAllRectangles();
        return Ok(rectangles);
    }

    [HttpGet("{id}")]
    public IActionResult GetRectangleById(int id)
    {
        var rectangle = rectangleService.GetRectangleById(id);
        if (rectangle == null)
        {
            return NotFound();
        }
        return Ok(rectangle);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateRectangle([FromBody] RectangleDto rectangleDto)
    {
        // Validate the input and handle errors
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Map the DTO to the entity
        var rectangle = new Rectangle
        {
            Length = rectangleDto.Length,
            Width = rectangleDto.Width
        };

        rectangleService.CreateRectangle(rectangle);

        return CreatedAtAction(nameof(GetRectangleById), new { id = rectangle.Id }, rectangle);
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult UpdateRectangle(int id, [FromBody] RectangleDto rectangleDto)
    {
        // Validate the input and handle errors
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingRectangle = rectangleService.GetRectangleById(id);
        if (existingRectangle == null)
        {
            return NotFound();
        }

        // Map the DTO to the entity
        existingRectangle.Length = rectangleDto.Length;
        existingRectangle.Width = rectangleDto.Width;

        rectangleService.UpdateRectangle(existingRectangle);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteRectangle(int id)
    {
        var existingRectangle = rectangleService.GetRectangleById(id);
        if (existingRectangle == null)
        {
            return NotFound();
        }

        rectangleService.DeleteRectangle(id);

        return NoContent();
    }
}
