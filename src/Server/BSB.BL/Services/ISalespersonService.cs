using BSB.Models.Models;
namespace BSB.BL.Services;

public interface ISalespersonService
{
    Task<(Salesperson salseperson, bool success, string errorMessage)> CreateSalespersonAsync(Salesperson salseperson);
    Task<(Salesperson salseperson, bool success, string errorMessage)> UpdateSalespersonAsync(string id, Salesperson salseperson);
    Task<(Salesperson salseperson, bool success, string errorMessage)> GetSalespersonByIdAsync(string Id);
    Task<(IEnumerable<Salesperson> salesperson, bool success, string errorMessage)> GetSalesPeopleAsync();
}
