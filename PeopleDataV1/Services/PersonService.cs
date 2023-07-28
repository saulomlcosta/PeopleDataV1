using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using PeopleDataV1.Data;
using PeopleDataV1.Entities;
using PeopleDataV1.Services.Interfaces;
using PeopleDataV1.ViewModels.Persons;
using System.Globalization;

namespace PeopleDataV1.Services
{
    public class PersonService : IPeopleservice
    {
        private readonly DbContextClass _context;
        private readonly IMapper _mapper;

        public PersonService(DbContextClass context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonViewModel>> GetAllAsync()
        {
            var persons = await _context.Persons.ToListAsync();
            return _mapper.Map<IEnumerable<PersonViewModel>>(persons);
        }

        public async Task<PersonViewModel> GetByIdAsync(Guid id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PersonViewModel>(person);
        }

        public async Task<PersonViewModel> AddAsync(RegisterPersonViewModel model)
        {
            var person = _mapper.Map<Person>(model);

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return _mapper.Map<PersonViewModel>(person);
        }

        public async Task<int> ImportPeopleFromCsvAsync(Stream csvStream, Guid userId)
        {
            using (var reader = new StreamReader(csvStream))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<RegisterPersonCsvViewModel>().ToList();
                var people = _mapper.Map<List<Person>>(records);

                foreach (var person in people)
                {
                    person.UserId = userId;
                }

                _context.Persons.AddRange(people);
                await _context.SaveChangesAsync();

                return people.Count;
            }
        }

        public async Task<PersonViewModel> UpdateAsync(UpdatePersonViewModel model)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == model.Id);

            _mapper.Map(model, person);

            _context.Persons.Update(person);
            await _context.SaveChangesAsync();

            return _mapper.Map<PersonViewModel>(person);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (person is null)
                return false;

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
