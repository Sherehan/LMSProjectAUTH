using LMSProject.Data.Models;
using LMSProject.Data.Models.Models;
using LMSProjectAUTH.Application.Services;
using LMSProjectAUTH.Application.ViewModel.AdminDB;
using LMSProjectAUTH.Application.ViewModel.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSProjectAUTH.Controllers
{
    public class AdminDbController : Controller
    {
        private readonly AdminDBService _adminService;

        public AdminDbController(AdminDBService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            var model = _adminService.GetMainStatistic();

            return View(model);


        }
    }
}
