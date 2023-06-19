using Microsoft.AspNetCore.Mvc;
using Projekt.Data;
using Projekt.Models;
using Projekt.ViewModel;
using System.Security.Claims;

namespace Projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            IEnumerable<DriversVm> listOfSection = (from objArticle in _context.Drivers
                                                           select new DriversVm()
                                                           {

                                                               Id = objArticle.Id,
                                                               Description = objArticle.Description,
                                                               UserName = objArticle.UserName
                                                              
                                                           }
                                                           ).ToList();
            return View(listOfSection);   
        }
        public IActionResult Details(int driverId)
        {
            IEnumerable<CommentVm> listOfComment = (from objComment in _context.Comments
                                                    where objComment.Id == driverId
                                                    select new CommentVm()
                                                    {
                                                        Id = objComment.Id,
                                                        Description = objComment.Description,
                                                        Rating = objComment.Rating,
                                                        DriverId = objComment.DriverId,
                                                        CreateOn = objComment.CreateOn,
                                                    }
                                                    ).ToList();
            ViewBag.DriverId = driverId;
            return View(listOfComment);
        }
        
        [HttpPost]
        public ActionResult AddComment(int driverId, int rating, string Description)
        {
            CommentModel objComment = new CommentModel();
            objComment.DriverId = driverId;
            objComment.Rating = rating;
            objComment.Description = Description;
            objComment.CreateOn = DateTime.Now;
            _context.Comments.Add(objComment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
