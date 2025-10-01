using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IAddDepartmentService addDepartmentService;
        private readonly IUpdateDepartmentService updateDepartmentService;
        private readonly IViewDepartmentService viewDepartmentService;
        private readonly IViewAllDepartmentService viewAllDepartmentService;

        public DepartmentController
            (
            IAddDepartmentService addDepartmentService, 
            IUpdateDepartmentService updateDepartmentService,
            IViewDepartmentService viewDepartmentService,
            IViewAllDepartmentService viewAllDepartmentService
            )
        {
            this.addDepartmentService = addDepartmentService;
            this.updateDepartmentService = updateDepartmentService;
            this.viewDepartmentService = viewDepartmentService;
            this.viewAllDepartmentService = viewAllDepartmentService;
        }

        [HttpPost("add-department")]
        public async Task<ActionResult<AddDepartmentResponse>> AddDepartment(DepartmentDto departmentDto)
        {
            var response = await addDepartmentService.AddDepartmentAsync(departmentDto);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("update-department")]
        public async Task<ActionResult<UpdateDepartmentResponse>> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            var response = await updateDepartmentService.UpdateDepartmentAsync(updateDepartmentDto);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("view-department")]
        public async Task<ActionResult<ViewDepartmentResponse>> ViewDepartment([FromQuery] DepartmentIdDto departmentIdDto)
        {
            var response = await viewDepartmentService.ViewDepartmentAsync(departmentIdDto);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("all-department")]
        public async Task<ActionResult<ViewAllDepartmentsReponse>> ViewAllDepartment()
        {
            var response = await viewAllDepartmentService.ViewAllDepartmentsAsync();

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
