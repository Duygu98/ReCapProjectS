using DataAccess.Abstack;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : IMemory
    {
        public void Add(Car entity)
        {
            if (entity.CarName.Length>2 && entity.DailyPrice>0)
            {
                using (CarDbContext context = new CarDbContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();

                }
            }
            else
            {
                Console.WriteLine("Araba ismi en az 2 karakter ve günlük fiyatı 0'dan büyük olmalıdır");
            }
        }

        public void Delete(Car entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {

            using (CarDbContext context = new CarDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {

            using (CarDbContext context = new CarDbContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> GetById(int entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {

            using (CarDbContext context = new CarDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
