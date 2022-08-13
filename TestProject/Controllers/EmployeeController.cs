using Microsoft.AspNetCore.Mvc;
using TestProject.DTO;
using TestProject.Models;
using TestProject.Services.EmployeeServices;


namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllAsync()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetByIdAsync(int id)
        {
            Employee employee = await _employeeService.GetByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Employee>> CreateAsync([FromBody] EmployeeDTO employeeDto)
        {
            Employee employee = await _employeeService.InsertAsync(employeeDto);
            return Ok(employee);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<ActionResult<Employee>> UpdateAsync([FromBody] Employee employee)
        {
            await _employeeService.UpdateAsync(employee);
            return Ok(employee);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<List<Employee>>> DeleteAsync([FromQuery] int id)
        {
            await _employeeService.DeleteAsync(id);
            return Ok(await _employeeService.GetAllAsync());
        }
    }
}
