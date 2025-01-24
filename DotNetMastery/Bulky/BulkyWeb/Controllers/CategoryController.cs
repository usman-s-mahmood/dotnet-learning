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
            Console.WriteLine($"Obj. Props.\nName: {obj.Name} | DisplayOrder: {obj.DisplayOrder}\nCheck: {obj.Name == null}");
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError(
                    "Name", // this is for key, the field for which this custom error is being made!
                    "Name and display order can't be same" // this is the custom error!
                );
            }
            if (obj.Name == null || obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError(
                    "",
                    "Invalid Name for Category!"
                );
                Console.WriteLine("Reached Here!");
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
                TempData["success"] = "Category Created!";
                return RedirectToAction("Index"); // second arg can be the name of controller if the controller of action is other than the Base Class!

            }
            return View();
        }
        [HttpGet]
        [Route("Category/Edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Console.WriteLine($"Id received is: {id}");
            Category? categoryFromDb = _db.Categories.Find(id); // Find will find the category on the basis of primary key
            Category? categoryFromDb1 = _db.Categories.FirstOrDefault(o => o.Id == id); // this method can find a record based on any attribute of the object!
            Category? categoryFromDb2 = _db.Categories.Where(o => o.Id == id).FirstOrDefault(); // just another method!

            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost]
        [Route("Category/EditCat")]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                //Console.WriteLine(obj);
                //Console.WriteLine($"Properties are: \nID: {obj.Id}\nName: {obj.Name}\n{obj.DisplayOrder}");
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
                return NotFound();
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == 0)
                return NotFound();
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
                return NotFound();
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted!";
            return RedirectToAction("Index");
        }

    }
}
