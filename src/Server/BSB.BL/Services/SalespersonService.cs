using AutoMapper;
using BSB.DataAccess;
using BSB.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BSB.BL.Services;

public class SalespersonService : ISalespersonService
{
    private IRepositoryManager repositoryManager;
    private IMapper mapper;
    public SalespersonService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.mapper = mapper;
    }

    public async Task<(Salesperson salseperson, bool success, string errorMessage)> CreateSalespersonAsync(Salesperson salseperson)
    {
        ArgumentNullException.ThrowIfNull(salseperson);

        var personToInsert = this.mapper.Map<Models.Entity.Salesperson>(salseperson);
        personToInsert.Id = Guid.NewGuid().ToString();
        var existingproduct = this.repositoryManager.SalespersonRepository.FindByCondition(
            p => p.FirstName.Equals(salseperson.FirstName) &&
            p.LastName.Equals(salseperson.LastName));
        if (existingproduct.Any(p => !p.IsDeleted))
        {
            return (null, false, "Saleperson already exist.");
        }
        this.repositoryManager.SalespersonRepository.Create(personToInsert);
        await this.repositoryManager.SaveChangesAsync();
        salseperson.Id = personToInsert.Id;
        return (salseperson, true, string.Empty);
    }

    public Task<(IEnumerable<Salesperson> salesperson, bool success, string errorMessage)> GetSalesPeopleAsync()
    {
        var query = this.repositoryManager.SalespersonRepository.FindByCondition(p => !p.IsDeleted);
        var salsepeople = this.mapper.Map<IEnumerable<Models.Models.Salesperson>>(query.ToList());
        return Task.FromResult((salsepeople, true, string.Empty));
    }

    public async Task<(Salesperson salseperson, bool success, string errorMessage)> GetSalespersonByIdAsync(string Id)
    {
        if (string.IsNullOrWhiteSpace(Id))
        {
            ArgumentNullException.ThrowIfNull(nameof(Id));
        }
        var salePersonQuery = this.repositoryManager.SalespersonRepository.FindByCondition(
            p => p.Id.Equals(Id) && !p.IsDeleted).Include(x => x.Manager);
        if (salePersonQuery.Any())
        {
            var salespersonToReturn = this.mapper.Map<Models.Models.Salesperson>(salePersonQuery.First());

            return (salespersonToReturn, true, string.Empty);
        }
        return (null, false, "No Salesperson found");
    }

    public async Task<(Salesperson salseperson, bool success, string errorMessage)> UpdateSalespersonAsync(string id, Salesperson salseperson)
    {
        ArgumentNullException.ThrowIfNull(salseperson);
        var query = this.repositoryManager.SalespersonRepository.FindByCondition(
            p => p.FirstName.Equals(salseperson.FirstName) &&
            p.LastName.Equals(salseperson.LastName)
            && !p.Id.Equals(id));
        if (query.Any(p => !p.IsDeleted))
        {
            return (null, false, "Salesperson already exist.");
        }

        var orginalentity = this.repositoryManager.SalespersonRepository.FindByCondition(x => x.Id.Equals(id)).FirstOrDefault();

        if (orginalentity == null)
        {
            return (null, false, "Salesperson does not exist.");
        }

        var manger = this.repositoryManager.SalespersonRepository.FindByCondition(x => x.Id.Equals(salseperson.ManagerId)).FirstOrDefault();
        orginalentity.Manager = manger;
        orginalentity.FirstName = salseperson.FirstName;
        orginalentity.LastName = salseperson.LastName;
        orginalentity.Phone = salseperson.Phone;
        orginalentity.Address = salseperson.Address;

        this.repositoryManager.SalespersonRepository.Update(orginalentity);

        await this.repositoryManager.SaveChangesAsync();

        return (salseperson, true, string.Empty);
    }

}
