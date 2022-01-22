using Core_MVC_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core_MVC_CRUD.Infrastructure.Repositories.Interface
{
    public interface ICategoryRepository
    {
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);

        Category GetByDefault(Expression<Func<Category, bool>> expression);
        List<Category> GetByDefaults(Expression<Func<Category, bool>> expression);
    }
}
