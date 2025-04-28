using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSalePrep.Web.Data.Entities;
using OnSalePrep.Web.Repositories;

namespace OnSalePrep.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
           _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryRepository.GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryRepository.CreateAsync(category);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Já existe uma categoria com o mesmo nome!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }
            return View(category);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryRepository.GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryRepository.UpdateAsync(category);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Já existe uma categoria com o mesmo nome!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }
            return View(category);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryRepository.GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if(category != null)
            {
                await _categoryRepository.DeleteAsync(category);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
