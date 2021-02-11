using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, AvisContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (AvisContext context = new AvisContext())
            {
                var result = from r in context.Rentals join c in context.Customers on r.CustomerId equals c.CustomerId join ca in context.Cars on r.CarId equals ca.Id select new RentalDetailDto { CarName = ca.Description, CustomerName = c.CompanyName, RentDate = r.RentDate};
                return result.ToList();
            }
        }
    }
}
