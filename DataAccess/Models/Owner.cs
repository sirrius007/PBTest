namespace DataAccess.Models;

public class Owner
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public ICollection<RealEstate>? RealEstates { get; set; }
}