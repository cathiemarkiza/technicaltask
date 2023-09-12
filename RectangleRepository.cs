public interface IRectangleRepository
{
    IEnumerable<Rectangle> GetAllRectangles();
    Rectangle GetRectangleById(int id);
    void AddRectangle(Rectangle rectangle);
    void UpdateRectangle(Rectangle rectangle);
    void DeleteRectangle(int id);
}

public class RectangleRepository : IRectangleRepository
{
    private readonly List<Rectangle> rectangles;

    public RectangleRepository()
    {
        rectangles = new List<Rectangle>();
    }

    public IEnumerable<Rectangle> GetAllRectangles()
    {
        return rectangles;
    }

    public Rectangle GetRectangleById(int id)
    {
        return rectangles.FirstOrDefault(r => r.Id == id);
    }

    public void AddRectangle(Rectangle rectangle)
    {
        rectangles.Add(rectangle);
    }

    public void UpdateRectangle(Rectangle rectangle)
    {
        var existingRectangle = rectangles.FirstOrDefault(r => r.Id == rectangle.Id);
        if (existingRectangle != null)
        {
            existingRectangle.Length = rectangle.Length;
            existingRectangle.Width = rectangle.Width;
        }
    }

    public void DeleteRectangle(int id)
    {
        var existingRectangle = rectangles.FirstOrDefault(r => r.Id == id);
        if (existingRectangle != null)
        {
            rectangles.Remove(existingRectangle);
        }
    }
}
