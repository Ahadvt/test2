using EduHome.Enum;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<Appuser> _userManager;
        private readonly SignInManager<Appuser> _signInManager;
        private readonly RoleManager<IdentityRole> _roloemanager;

        public AccountController(UserManager<Appuser> userManager,SignInManager<Appuser> signInManager,RoleManager<IdentityRole> roloemanager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roloemanager = roloemanager;
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Index()
        {
            List<Appuser> admins = _userManager.Users.Where(u => u.Isadmin == true).ToList();
            ViewBag.Roles = _roloemanager.Roles.ToList();
            return View(admins);
        }

        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {

            if (login.UserName == null)
            {
                ModelState.AddModelError("", "name or pasword incorrect");
                return View();
            }
            if (login.Password == null)
            {
                ModelState.AddModelError("", "name or pasword incorrect");
                return View();
            }
            if (!ModelState.IsValid) return View();
            Appuser user = await _userManager.FindByNameAsync(login.UserName);

            if (user.Isadmin == false)
            {
                ModelState.AddModelError("", "Username or pasword incorrect");
                return View();
            }

            if (user == null)
            {
                ModelState.AddModelError("", "username or pasword incorrect");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or pasword incorrect");
                return View();
            }
            return RedirectToAction("index", "setting");
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult AdminCreate()
        {
            ViewBag.Roles = _roloemanager.Roles.ToList();

            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>AdminCreate(RegisterVM register)
        {
            ViewBag.Roles = _roloemanager.Roles.ToList();
            if (!ModelState.IsValid) return View();
            Appuser appuser = new Appuser
            {
                Name = register.Name,
                Surname = register.SurName,
                Email = register.Email,
                UserName = register.UserName,
                Isadmin = true,
                Roles = register.Role

            };

          IdentityResult result=  await _userManager.CreateAsync(appuser, register.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            //await _userManager.CreateAsync(appuser, "Ahad1234");
            await _userManager.AddToRoleAsync(appuser, register.Role);
          return  RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login","account");
        }

        public async Task<IActionResult> EditAdmin(string id, EditAdminVm adminvm)
        {
            Appuser Admins = await _userManager.FindByIdAsync(id);

            EditAdminVm editAdminVm = new EditAdminVm
            {
                UserName = Admins.UserName,
                Name= Admins.Name,
                SurName= Admins.Surname,
                Email= Admins.Email,
                Role= Admins.Roles,
            };
            ViewBag.Roles = _roloemanager.Roles.ToList();
            return View(editAdminVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EditAdmin")]

        public async Task<IActionResult> EditAdminPost(string id, EditAdminVm adminvm)
        {

            if (adminvm.UserName == null)
            {
                ModelState.AddModelError("UserName", "required");
                return View();
            }
            if (adminvm.Name == null)
            {
                ModelState.AddModelError("Name", "required");
                return View();
            }
            if (adminvm.SurName == null)
            {
                ModelState.AddModelError("SurName", "required");
                return View();
            }
            if (adminvm.Email == null)
            {
                ModelState.AddModelError("Email", "required");
                return View();
            }

            if (!ModelState.IsValid) return View();

           
            Appuser Admins = await _userManager.FindByIdAsync(id);
            ViewBag.Roles = _roloemanager.Roles.ToList();
            if (adminvm.Role.Contains("User"))
            {
                Admins.Isadmin = false;
            }
            EditAdminVm eadmin = new EditAdminVm
            {
                UserName = Admins.UserName,
                Name = Admins.Name,
                SurName = Admins.Surname,
                Email = Admins.Email,
                Role = Admins.Roles,


            };
           

            //if (_userManager.FindByNameAsync(adminvm.UserName)==null)
            //{
            //    ModelState.AddModelError("", "this username alrady exsist");
            //    return View(eadmin);

            //}
            if (string.IsNullOrWhiteSpace(adminvm.CurrentPasword))
            {
                Admins.UserName = adminvm.UserName;
                Admins.Name = adminvm.Name;
                Admins.Surname = adminvm.SurName;
                Admins.Email = adminvm.Email;
                Admins.Roles = adminvm.Role;
                await _userManager.UpdateAsync(Admins);


            }
            else
            {
                Admins.UserName = adminvm.UserName;
                Admins.Name = adminvm.Name;
                Admins.Surname = adminvm.SurName;
                Admins.Email = adminvm.Email;
                Admins.Roles = adminvm.Role;

                IdentityResult Result = await _userManager.ChangePasswordAsync(Admins, adminvm.CurrentPasword, adminvm.Password);
                if (!Result.Succeeded)
                {
                    foreach (var item in Result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                    return View(eadmin);
                }
              
            }


            return RedirectToAction("index", "account");
        }

    }
}
