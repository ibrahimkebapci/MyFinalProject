using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //core katmanı diğer katanları almaz
    //generic constraint
    //T nin hangi türdeki parametreler olduğuna aşağıdaki isimlendirmeler ile karar veriyoruz
    //class:referans tip olabilir demek
    //IEntity:Ientity olabilir veya IEntity implement eden bir nesne olabilir
    //new():new'lenebilir olmalı demek
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
