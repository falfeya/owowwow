using CRM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CRM.Controllers
{

    //[Authorize(Roles = "Admin")]
    public class WorkerController : Controller
    {
        DiaryApiStore diary = new DiaryApiStore();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var app = await diary.AllNotes();
            return View(app);
        }
    }
}
