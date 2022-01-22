using Core_MVC_CRUD.Infrastructure.Repositories.Interface;
using Core_MVC_CRUD.Models.DTOs;
using Core_MVC_CRUD.Models.Entities.Abstract;
using Core_MVC_CRUD.Models.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_MVC_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;
                _categoryRepository.Create(category);
                return View();
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult List()
        {
            return View(_categoryRepository.GetByDefaults(x => x.Status != Status.Passive));
        }

        public IActionResult Update(int id)
        {
            Category category = _categoryRepository.GetByDefault(x => x.Id == id);
            UpdateCategoryDTO model = new UpdateCategoryDTO();
            model.Id = category.Id;
            model.Name = category.Name;
            model.Description = category.Description;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = _categoryRepository.GetByDefault(x => x.Id == model.Id);
                category.Name = model.Name;
                category.Description = model.Description;
                _categoryRepository.Update(category);
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            Category category = _categoryRepository.GetByDefault(x => x.Id == id);
            _categoryRepository.Delete(category);
            return RedirectToAction("List");
        }
    }
}
