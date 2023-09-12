using System.ComponentModel.DataAnnotations;

public class RectangleDto
{
    [Required]
    public double Length { get; set; }

    [Required]
    public double Width { get; set; }
}
