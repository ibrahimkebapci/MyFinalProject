using DataAccess.Abstract;
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
    //NuGet 
    public class EfProductDal : IProductDal
    {

        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c# 
            //belleği hızlıca temizlemek için ,using bittikten sonra bellek temizleniyor
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
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
            using(NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }
        //paramatre olarak bir landa yolluyoruz böylece yazdığımız bütün tipleri
        //getirebiliyoruz 
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //filter null ise tümünü getir değil ise : ile filitrele gösterilir
                return filter == null
                ? context.Set<Product>().ToList()
                //select * from pruduct döndürmek gibi , üst taraftaki satır
                : context.Set<Product>().Where(filter).ToList();
                //koşul belirleyip istediğimiz değeri yazıypruz

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
