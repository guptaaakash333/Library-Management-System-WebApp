using LibraryManagementSystemWebApplication.GenericRepository;
using LibraryManagementSystemWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemWebApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly IGenericRepositoryLMS<Books> _BooksObj;

        public BooksController(IGenericRepositoryLMS<Books> AdminObj)
        {
            _BooksObj = AdminObj;
        }
        [HttpGet]
        public IActionResult Addbook()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Addbook(Books model)
        {
            if (model != null)
            {
                bool temp = _BooksObj.Create(model);
                //var BooksList = _BooksObj.Read();
                if (temp)
                {
                    //var BooksList = _BooksObj.Read();
                    //TempData["Id"] = model.Id;
                    //TempData["Title"] = model.Title;
                    //TempData["Author"] = model.Author;
                    //TempData["Availability"] = model.Availability;
                    TempData["Message"] = "Book Added successfully !!!";
                    return RedirectToAction("BookList");
                }
            }
            return View();
        }


        // show all the books in DB 
        [HttpGet]
        public IActionResult BookList()
        {
            var BooksList = _BooksObj.Read();
            //return View();
            return View(BooksList);
        }



        //Edit books 
        [HttpPost]
        /* public IActionResult EditBook(int Id)
         {
             var book = _BooksObj.Read().Find(x => x.Id == Id);
             if (book != null)
             {
                 bool temp = _BooksObj.Update(book);
                 if (temp)
                 {
                     return RedirectToAction("BookList", "Books");
                 }
             }
             return View();
         }*/


        //public IActionResult EditBook(Books model)
        //{
        //	if (model != null)
        //	{
        //              bool temp = _BooksObj.Update(model);
        //              if (temp)
        //              {
        //                  return RedirectToAction("Booklist","Books");
        //              }
        //              //var book = _BooksObj.Set<T>().Find(model);
        //          }
        //	return View();
        //}

        /*public IActionResult Delete(int Id)
		{

			var book = _BooksObj.Read().FirstOrDefault(x => x.Id == Id);
			if (book is not null)
			{
				_BooksObj.Delete(book);
				return RedirectToAction("Booklist", "Books");
			}
				return View();
		*/

        [HttpGet]
        public IActionResult GetBookDetails(int id)
        {
            var book = _BooksObj.Read().Find(x => x.Id == id);
            if (book != null)
            {
                return Json(book); // Return the book details as JSON
            }
            return Json(null); // Return null if book not found
        }



        public IActionResult EditBook(int bookId)
        {
            var book = _BooksObj.Read().Find(x => x.Id == bookId);
            
                if (book == null)
                {
                    return NotFound();
                }
            return View(book);
        }

        [HttpPost]
        public IActionResult EditBook(int bookId, Books book)
        {
            if (bookId != book.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _BooksObj.Update(book);
                TempData["Message"] = "Book updated successfully !!!.";
                return RedirectToAction("BookList");
            }
            return View(book);
        }


        [HttpGet]
        public IActionResult DeleteMyBooks(int Id)
        {
            var book = _BooksObj.Read().Find(b => b.Id == Id);
            if (book is not null)
            {
                _BooksObj.Delete(book);
                TempData["Message"] = "Book Deleted !!!.";
                return RedirectToAction("BookList");
            }
            return View(); // Handle case when book with given ID is not found
        }

        [HttpPost]
        public IActionResult DeleteBook(Books model)
        {
            var book = _BooksObj.Read().Find(b => b.Id == model.Id);
            if (book is not null)
            {
                _BooksObj.Delete(book);
                return RedirectToAction("BookList", "Books");
            }
            else
            {
                // Handle case when book with given ID is not found
                ViewBag.ErrorMessage = "Book with ID " + model.Id + " not found.";
                return RedirectToAction("BookList", "Books");
            }
        }


    }
}
