using AutoMapper;
using BSB.DataAccess;
using BSB.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSB.BL.Services;

public class CustomerServcie : ICustomerService
{
    private IRepositoryManager repositoryManager;
    private IMapper mapper;
    public CustomerServcie(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.mapper = mapper;
    }

    public async Task CreateCutomerAsync(Customer customer)
    {
        var cus = this.mapper.Map<Models.Entity.Customer>(customer);
        this.repositoryManager.CustomerRepository.Create(cus);
        await this.repositoryManager.SaveChangesAsync();
    }

}
