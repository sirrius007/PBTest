namespace DataAccess.Models;

public class RealEstate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }
}