using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSalePrep.Web.Data.Entities;
using OnSalePrep.Web.Repositories;

namespace OnSalePrep.Web.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IRepository _repository;

        public CountriesController(IRepository repository)
        {
            _repository = repository;
        }

       
        public IActionResult Index()
        {
            return View(_repository.GetCountries());
        }

        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _repository.GetCountry(id.Value);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.AddCountry(country);
                    await _repository.SaveAllAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Já existe um país com o mesmo nome!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch(Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
                
            }
            return View(country);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _repository.GetCountry(id.Value);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.UpdateCountry(country);
                    await _repository.SaveAllAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Já existe um país com o mesmo nome!");
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
            return View(country);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _repository.GetCountry(id.Value);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = _repository.GetCountry(id);
            _repository.RemoveCountry(country);
            await _repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
