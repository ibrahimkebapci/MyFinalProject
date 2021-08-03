using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constraint
    // class:referans tip olabilir demek
    //IEntity : Ientity olabilir veya IEntity implement eden bir nesne olabilir
    //new() : new'lenebilir olmalı
    //parametrerelri aşağıdaki gibi koşullar ile seçiyoruz
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression <Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
