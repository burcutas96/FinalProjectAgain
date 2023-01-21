using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //Northwind'i using kullanmadan eklesekte olurdu ancak using, projenin daha performanslı çalışmasını sağlıyor.

            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //entity'i context ile yani veri kaynağıyla ilişkilendir
                addedEntity.State = EntityState.Added;   //Ekleme olarak durumunu set et
                context.SaveChanges();  //Ve ekle, değişiklikleri kaydet.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); 
                deletedEntity.State = EntityState.Deleted;   
                context.SaveChanges();  
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Eğer filtre verilmemişse DbSet'deki Product'a yerleş ve ona karşılık gelen Products tablosundaki tüm verileri getir.
                //filtre verilmişse de verilere where koşuluyla filtre uygulayarak verileri getir.
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
