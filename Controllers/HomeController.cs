using GameStoreASP_Net.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace GameStoreASP_Net.Controllers
{
    public class HomeController : Controller
    {
        private GameStoreContext db;

        public HomeController(GameStoreContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Singin()
        {
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                return RedirectToAction("Store", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Singin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.LoginUser == model.Login && u.PasswordUser == model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("AuthUser", model.Login);
                    await Authenticate(model.Login);

                    return RedirectToAction("Store", "Home");
                }
                ModelState.AddModelError(" ", "Некорректно введен логин или пароль");
            }

            return RedirectToAction("Singin", "Home");
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("AuthUser");
            return RedirectToAction("Singin");

        }

        public IActionResult Registation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registation (User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Singin");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public async Task<IActionResult> Store()
        {
            return View(await db.Games.ToListAsync());
        }

        public IActionResult Cart()
        {
            Carts cart = new Carts();

            if (HttpContext.Session.Keys.Contains("Carts"))
            {
                cart = JsonSerializer.Deserialize<Carts>(HttpContext.Session.GetString("Carts"));
            }

            return View(cart);
        }

        public IActionResult AddToCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);

            Carts cart = new Carts();

            if (HttpContext.Session.Keys.Contains("Carts"))
            {
                cart = JsonSerializer.Deserialize<Carts>(HttpContext.Session.GetString("Carts"));
            }

            cart.CartLines.Add(db.Games.Find(ID));

            HttpContext.Session.SetString("Carts", JsonSerializer.Serialize<Carts>(cart));

            return RedirectToAction("Store");

        }

        public IActionResult RemoveFromCart()
        {
            int number = Convert.ToInt32(Request.Query["Number"]);

            Carts cart = new Carts();

            if (HttpContext.Session.Keys.Contains("Carts"))
            {
                cart = JsonSerializer.Deserialize<Carts>(HttpContext.Session.GetString("Carts"));
            }

            cart.CartLines.RemoveAt(number);

            HttpContext.Session.SetString("Carts", JsonSerializer.Serialize<Carts>(cart));

            return RedirectToAction("Cart");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}