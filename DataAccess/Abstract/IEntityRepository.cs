using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{                                         //generic constraint: generic kısıtlama 
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //Expression: Çektiğimiz ürünleri filtrelemek için kullanılır.
        List<T> GetAll(Expression<Func<T,bool>> filter = null);  //filter = null: Yani filtre vermeyedebilir.
        T Get(Expression<Func<T, bool>> filter);   //Tek bir ürünün detayına gitmek için kullanılır.              
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
