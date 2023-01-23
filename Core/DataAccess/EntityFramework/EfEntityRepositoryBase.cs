using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //Northwind'i using kullanmadan eklesekte olurdu ancak using, projenin daha performanslı çalışmasını sağlıyor.

            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //entity'i context ile yani veri kaynağıyla ilişkilendirip, Entry ile veri kaynağındaki referansı yakalarız
                addedEntity.State = EntityState.Added;   //Ekleme olarak durumunu set et
                context.SaveChanges();  //Ve ekle, değişiklikleri kaydet.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //Eğer filtre verilmemişse DbSet'deki TEntity'a yerleş ve ona karşılık gelen TEntitys tablosundaki tüm verileri getir.
                //filtre verilmişse de verilere where koşuluyla filtre uygulayarak verileri getir.
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
