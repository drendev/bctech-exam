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
        private readonly IUpdateEmployeeService updateEmployeeService;
        private readonly IViewEmployeeService viewEmployeeService;
        public EmployeeController
            (
            IAddEmployeeService addEmployeeService, 
            IRemoveEmployeeService removeEmployeeService,
            IUpdateEmployeeService updateEmployeeService,
            IViewEmployeeService viewEmployeeService
            )
        {
            this.addEmployeeService = addEmployeeService;
            this.removeEmployeeService = removeEmployeeService;
            this.updateEmployeeService = updateEmployeeService;
            this.viewEmployeeService = viewEmployeeService;
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

        [HttpPut("update-employee")]
        public async Task<ActionResult<UpdateEmployeeResponse>> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var response = await updateEmployeeService.UpdateEmployeeAsync(updateEmployeeDto);

            if (!response.Sucess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("view-employee")]
        public async Task<ActionResult<ViewEmployeeResponse>> ViewEmployee(EmployeeIdDto employeeIdDto)
        {
            var response = await viewEmployeeService.GetEmployeeAsync(employeeIdDto);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
