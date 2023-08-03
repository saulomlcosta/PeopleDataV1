using Microsoft.AspNetCore.Mvc;
using PeopleDataV1.Extensions;
using PeopleDataV1.Services.Interfaces;
using PeopleDataV1.ViewModels;
using PeopleDataV1.ViewModels.Persons;

namespace PeopleDataV1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPeopleservice _peopleservice;

        public PersonController(IPeopleservice Peopleservice)
        {
            _peopleservice = Peopleservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 25
            )
        {
            var result = await _peopleservice.GetAllAsync(page, pageSize);

            if (result.Items is null)
                return NoContent();

            return Ok(new ResultViewModel<dynamic>(new
            {
                result.TotalCount,
                page,
                pageSize,
                result.Items
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var person = await _peopleservice.GetByIdAsync(id);

            if (person is null)
                return NotFound(new ResultViewModel<PersonViewModel>("Person not found"));

            return Ok(new ResultViewModel<PersonViewModel>(person));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(RegisterPersonViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<PersonViewModel>(ModelState.GetErrors()));

            var createPerson = await _peopleservice.AddAsync(model);
            return Created($"person/{createPerson.Id}", new ResultViewModel<PersonViewModel>(createPerson));
        }

        [HttpPost("import/{id}")]
        public async Task<IActionResult> ImportCsv([FromForm] IFormFile file, Guid id)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file or empty file provided.");
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var importedPeopleCount = await _peopleservice.ImportPeopleFromCsvAsync(memoryStream, id);

                return Ok(new ResultViewModel<dynamic>(new
                {
                    total = importedPeopleCount,
                    message = "Imported Successfully!"
                }));
            }
        }


        [HttpPut()]
        public async Task<IActionResult> Put(UpdatePersonViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<PersonViewModel>(ModelState.GetErrors()));

            var updatePerson = await _peopleservice.UpdateAsync(model);

            return Ok(new ResultViewModel<PersonViewModel>(updatePerson));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            bool personDeleted = await _peopleservice.DeleteAsync(id);

            if (!personDeleted)
                return NotFound(new ResultViewModel<PersonViewModel>("Person not found"));

            return Ok(new ResultViewModel<dynamic>(new
            {
                Message = "Person Deleted Successfully!"
            }));
        }
    }
}
