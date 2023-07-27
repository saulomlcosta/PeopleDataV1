using Microsoft.AspNetCore.Mvc;
using PeopleDataV1.Entities;
using PeopleDataV1.Services.Interfaces;
using PeopleDataV1.ViewModels.Peoples;
using PeopleDataV1.ViewModels.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeopleDataV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public IEnumerable<People> GetAll()
        {
            return _peopleService.GetAll();
        }

        [HttpGet("{id}")]
        public People GetById(Guid id)
        {
            return _peopleService.GetById(id);
        }

        [HttpPost]
        public People Create(RegisterPeopleViewModel model)
        {
            return _peopleService.Add(model);
        }

        [HttpPut()]
        public People Put(People model)
        {
            return _peopleService.Update(model);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return _peopleService.Delete(id);
        }
    }
}
