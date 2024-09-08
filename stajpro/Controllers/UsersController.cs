using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Services.Contracts;
using Entities.Models;
using stajpro.Models;
using Entities.Dtos;
using Services.Helper;
using Repositories.Contracts;
namespace stajpro.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _userManager;
        private readonly IRepositoryManager _context;

        public UsersController(IUsersService userManager, IRepositoryManager context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.userEmail))
                {
                    ModelState.AddModelError("userEmail", "E-posta adresi gereklidir.");
                    return View(model);
                }

                Users user = await _userManager.GetUserByEmail(model.userEmail);

                if (user is null)
                {
                    ModelState.AddModelError("userEmail", "Kullanıcı bulunamadı.");
                    return View(model);
                }

                string password = user.userPassword;
                string decryptedPassword = AesEncryptionHelper.Decrypt(password, "your-password-here");

                if (decryptedPassword == model.userPassword)
                {
                return RedirectToAction("Index", "Dashboard", new { area = "User"});
                }
                else
                {
                    ModelState.AddModelError("userPassword", "Şifre hatalı.");
                }
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            var existingUser = await _userManager.GetUserByEmail(model.userEmail);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Bu email adresi zaten kullanılıyor.");
                return View();
            }

            if (ModelState.IsValid)
            {
                string password = model.userPassword;
                string encryptedPassword = AesEncryptionHelper.Encrypt(password, "your-password-here");
                Users user = new()
                {
                    userName = model.userName,
                    userSurname = model.userSurname,
                    userEmail = model.userEmail,
                    userPassword = encryptedPassword,
                    userBirthDate = model.userBirthDate
                };
                _userManager.CreateUser(user);

                return View("Index", new LoginModel
                {
                    isUserCreated = true
                });
            }

            return View();
        }
    }
}