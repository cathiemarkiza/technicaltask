public interface IRectangleService
{
    IEnumerable<Rectangle> GetAllRectangles();
    Rectangle GetRectangleById(int id);
    void CreateRectangle(Rectangle rectangle);
    void UpdateRectangle(Rectangle rectangle);
    void DeleteRectangle(int id);
}

public class RectangleService : IRectangleService
{
    private readonly IRectangleRepository repository;

    public RectangleService(IRectangleRepository repository)
    {
        this.repository = repository;
    }

    public IEnumerable<Rectangle> GetAllRectangles()
    {
        return repository.GetAllRectangles();
    }

    public Rectangle GetRectangleById(int id)
    {
        return repository.GetRectangleById(id);
    }

    public void CreateRectangle(Rectangle rectangle)
    {
        repository.AddRectangle(rectangle);
    }

    public void UpdateRectangle(Rectangle rectangle)
    {
        repository.UpdateRectangle(rectangle);
    }

    public void DeleteRectangle(int id)
    {
        repository.DeleteRectangle(id);
    }
}
