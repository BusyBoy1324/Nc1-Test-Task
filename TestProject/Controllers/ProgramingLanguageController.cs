using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.DTO;
using TestProject.Models;
using TestProject.Services.ProgramingLanguageServices;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguageController : ControllerBase
    {
        private readonly IProgramingLanguageServices _programingServices;

        public ProgramingLanguageController(IProgramingLanguageServices programingServices)
        {
            _programingServices = programingServices;
        }

        [HttpGet]
        [Route("ProgramingLanguages")]
        public async Task<ActionResult<List<ProgramingLanguage>>> GetAllAsync()
        {
            return Ok(await _programingServices.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramingLanguage>> GetByIdAsync(int id)
        {
            ProgramingLanguage programingLanguage = await _programingServices.GetByIdAsync(id);
            return Ok(programingLanguage);
        }

        [HttpPost]
        [Route("AddProgramingLanguage")]
        public async Task<ActionResult<ProgramingLanguage>> CreateAsync([FromBody]ProgramingLanguageDTO programingLanguageDto)
        {
            ProgramingLanguage programingLanguage = await _programingServices.InsertAsync(programingLanguageDto);
            return Ok(programingLanguage);
        }

        [HttpPut]
        [Route("UpdateProgramingLanguage")]
        public async Task<ActionResult<ProgramingLanguage>> UpdateAsync([FromBody] ProgramingLanguage programingLanguage)
        {
            await _programingServices.UpdateAsync(programingLanguage);
            return Ok(programingLanguage);
        }

        [HttpDelete]
        [Route("DeleteProgramingLanguage")]
        public async Task<ActionResult<List<ProgramingLanguage>>> DeleteAsync([FromQuery] int id)
        {
            await _programingServices.DeleteAsync(id);
            return Ok(await _programingServices.GetAllAsync());
        }
    }
}
