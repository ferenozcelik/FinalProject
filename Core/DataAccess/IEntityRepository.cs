using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // T, Generic çalışacak

    //generic constraint = generic kısıt
    public interface IEntityRepository<T> where T:class, IEntity, new()
        // class: T artık bir referans tip olmak zorunda, yani int vb. yazılamaz.
        // IEntity: T ya "IEntity olabilir" ya da IEntity'den implemente edilmiş bir şey olabilir.
        // new(): new'lenebilir olmak zorunda. IEntity interface olmadığı için new'lenemez. 
        // Bu yüzden artık IEntity'de yazılamaz. Artık sadece Category, Customer, Product vs. ile çalışır.
    {

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter); // T tipini returnleyen bir metod, tek bir veriyi returnlemek için kullanılabilir.
        
    }
}
