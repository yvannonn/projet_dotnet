
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Models;


namespace Blog.Controllers
{
    public class AuthController : Controller
    {        

       
        private readonly BlogDbContext _context;

        public AuthController(BlogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }


        // Pour Afficher le formulaire 

        public IActionResult register()
        {
            return RedirectToAction("Create", "Users");


        }
        // pour soumettre
        [HttpPost]
        public async Task<IActionResult> login(string email, string password)
        {


           
                var user = await _context.Users
                   .FirstOrDefaultAsync(e => e.Email == email && e.Password == password);

                if (user != null)
                {

                    
                    HttpContext.Response.Cookies.Append("id", user.Id.ToString());
                    HttpContext.Response.Cookies.Append("auteur_role", "Connecte");
                return RedirectToAction("Index", "Articles");
                }
            

            

            // sin on retourne  pas trouve 
            return View();



        }

          


            

           

    }
}