using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IAddEmployeeService addEmployeeService;
        private readonly IRemoveEmployeeService removeEmployeeService;

        public EmployeeController(IAddEmployeeService addEmployeeService, IRemoveEmployeeService removeEmployeeService)
        {
            this.addEmployeeService = addEmployeeService;
            this.removeEmployeeService = removeEmployeeService;
        }

        [HttpPost("add-employee")]
        public async Task<ActionResult<AddEmployeeResponse>> AddEmployee(EmployeeDto employeeDto)
        {
            var response = await addEmployeeService.AddAsync(employeeDto);

            if (!response.Response) return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete-employee")]
        public async Task<ActionResult<RemoveEmployeeResponse>> RemoveEmployee(EmployeeIdDto employeeIdDto)
        {
            var response = await removeEmployeeService.RemoveEmployeeAsync(employeeIdDto);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
