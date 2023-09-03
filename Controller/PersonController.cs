using Microsoft.AspNetCore.Mvc;
using Data.Repositories;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;  // Added for Task

namespace Controller
{
    [ApiController]
    [Route("api/Person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository personRepository)  // Fixed parameter name
        {
            _repository = personRepository;  // Fixed field assignment
        }

        [HttpGet]
        public async Task<IEnumerable<PersonModel>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<PersonModel> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task Add(PersonModel person)
        {
            await _repository.AddAsync(person);
        }

        [HttpPut]
        public async Task Update(PersonModel person)
        {
            await _repository.UpdateAsync(person);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
