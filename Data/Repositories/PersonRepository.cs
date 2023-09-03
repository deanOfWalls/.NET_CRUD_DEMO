using System;  // Added for Exception
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;  // Added for ToListAsync and FindAsync

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonModel>> GetAllAsync()
        {
            try
            {
                return await _context.Persons.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                return null;
            }
        }

        public async Task<PersonModel> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Persons.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                return null;
            }
        }

        public async Task AddAsync(PersonModel person)
        {
            try
            {
                await _context.Persons.AddAsync(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
            }
        }

        public async Task UpdateAsync(PersonModel person)
        {
            try
            {
                _context.Persons.Update(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var person = await _context.Persons.FindAsync(id);
                if (person != null)
                {
                    _context.Persons.Remove(person);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
            }
        }
    }
}
