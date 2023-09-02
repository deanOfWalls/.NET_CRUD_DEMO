using Microsoft.AspNetCore.Mvc;
using Repositories;  // Correct namespace for IPersonRepository
using Models;  // Correct namespace for PersonModel
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controller  // Custom namespace
{
    [ApiController]
    [Route("api/Person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository personRepository)
        {
            _repository = personRepository;
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
