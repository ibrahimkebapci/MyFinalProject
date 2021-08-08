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
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity>
              where TEntity : class, IEntity , new()
              where TContext:DbContext,new()
    {

        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c# 
            //belleği hızlıca temizlemek için ,using bittikten sonra bellek temizleniyor
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
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
        //paramatre olarak bir landa yolluyoruz böylece yazdığımız bütün tipleri
        //getirebiliyoruz 
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //filter null ise tümünü getir değil ise : ile filitrele gösterilir
                return filter == null
                ? context.Set<TEntity>().ToList()
                //select * from pruduct döndürmek gibi , üst taraftaki satır
                : context.Set<TEntity>().Where(filter).ToList();
                //koşul belirleyip istediğimiz değeri yazıypruz

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
