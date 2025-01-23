using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyWeb.Controllers
{
    public class CategoryController: Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList(); // var can also be used
            return View(objCategoryList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError(
                    "Name", // this is for key, the field for which this custom error is being made!
                    "Name and display order can't be same" // this is the custom error!
                );
            }
            if (obj.Name != null || obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError(
                    "",
                    "Invalid Name for Category!"
                );
            }

            if (obj.DisplayOrder == 0)
            {
                ModelState.AddModelError(
                    "",
                    "Invalid Value for display number!"
                );
            }
            if (ModelState.IsValid) // this will make sure that the object details are inline with the data annotations defined in the model!
            {
                _db.Categories.Add(obj); // this will make the new category object
                _db.SaveChanges(); // this will apply changes to database
                return RedirectToAction("Index"); // second arg can be the name of controller if the controller of action is other than the Base Class!

            }
            return View();
        }
    }
}
