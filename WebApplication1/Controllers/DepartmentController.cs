using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Model;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _dep;
        public DepartmentController(IDepartmentService dep)
        {
            _dep = dep;
        }
        public IActionResult Index()
        {
            return View(_dep.GetAll());
        }
        public IActionResult Detail(int id)
        {
            var model = _dep.GetById(id);
            return View(model);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] Department dep)
        {
            if (!ModelState.IsValid)
            {
                return View(dep);
            }
            var result = await _dep.CreateAsync(dep);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(dep);
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Update([FromForm] Department dep)
        {
            if (!ModelState.IsValid)
            {
                return View(dep);
            }
            var result = await _dep.UpdateAsync(dep);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(dep);
        }
    }
}
