namespace PBTestServices.DTOs;

public class OwnerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public IEnumerable<RealEstateDto> RealEstates { get; set; } = new List<RealEstateDto>();
}