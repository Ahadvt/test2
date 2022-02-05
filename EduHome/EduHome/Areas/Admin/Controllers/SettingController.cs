using EduHome.Dal;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        public SettingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Setting setting = _context.Setting.FirstOrDefault();
            return View(setting);
        }

        public IActionResult Edit()
        {
            Setting setting = _context.Setting.Include(s=>s.SociamMediaSettings).FirstOrDefault();
            return View(setting);
        }
        public IActionResult Edit(Setting setting)
        {
            Setting settingEdit = _context.Setting.Include(s => s.SociamMediaSettings).FirstOrDefault(s => s.Id == setting.Id);
            if (!ModelState.IsValid) return NotFound();
            
            return View();
        }
    }

}
