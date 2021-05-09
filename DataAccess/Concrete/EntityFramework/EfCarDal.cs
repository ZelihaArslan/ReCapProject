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
    //NuGet
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalDatabaseContext context = new CarRentalDatabaseContext())
            {
                //arabalarla modelleri join et
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join r in context.Colors
                             on c.ColorId equals r.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId, ModelYear = c.ModelYear,
                                 BrandName = b.BrandName, DailyPrice = c.DailyPrice, ColorName= r.ColorName
                          
                             };
                return result.ToList();
            }
        }
    }
}
