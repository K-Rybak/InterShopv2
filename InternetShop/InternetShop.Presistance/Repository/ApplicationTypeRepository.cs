using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entities;
using System;
using System.Collections.Generic;
namespace InternetShop.Presistance.Repository
{
    public class ApplicationTypeRepository : GenericRepository<ApplicationType>, IApplicationTypeRepository
    {
        public ApplicationTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
