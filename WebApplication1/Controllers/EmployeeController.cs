using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data.Model;
using WebApplication1.ModelViews;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _emp;
        public EmployeeController(IEmployeeService employeeService)
        {
            _emp = employeeService;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Employee> model = _emp.GetAll();

            return Ok(model);
        }
        [HttpGet("Details/{id}")]
        public IActionResult Detail(int id)
        {
            Employee model = _emp.GetById(id);
            return View(model);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]EmployeeCreate request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result =await _emp.CreateAsync(request);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View(request);
        }
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            Employee model = _emp.GetById(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Update([FromForm] Employee request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _emp.UpdateAsync(request);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View(request);
        }
        [HttpGet("Delate/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rs =await _emp.Delete(id);
            if (rs)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
