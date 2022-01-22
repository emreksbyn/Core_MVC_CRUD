using Core_MVC_CRUD.Infrastructure.Context;
using Core_MVC_CRUD.Infrastructure.Repositories.Interface;
using Core_MVC_CRUD.Models.Entities.Abstract;
using Core_MVC_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core_MVC_CRUD.Infrastructure.Repositories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }


        public void Create(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Category entity)
        {
            entity.DeleteDate = DateTime.Now;
            entity.Status = Status.Passive;
            _context.SaveChanges();
        }

        public Category GetByDefault(Expression<Func<Category, bool>> expression)
        {
            return _context.Categories.FirstOrDefault(expression);
        }

        public List<Category> GetByDefaults(Expression<Func<Category, bool>> expression)
        {
            return _context.Categories.Where(expression).ToList();
        }

        public void Update(Category entity)
        {
            entity.Status = Status.Modified;
            entity.UpdateDate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
