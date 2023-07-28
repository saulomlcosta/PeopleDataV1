﻿using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using PeopleDataV1.Data;
using PeopleDataV1.Entities;
using PeopleDataV1.Services.Interfaces;
using PeopleDataV1.ViewModels.Peoples;
using System.Globalization;

namespace PeopleDataV1.Services
{
    public class Peopleservice : IPeopleservice
    {
        private readonly DbContextClass _context;
        private readonly IMapper _mapper;

        public Peopleservice(DbContextClass context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PeopleViewModel>> GetAllAsync()
        {
            var persons = await _context.Peoples.ToListAsync();
            return _mapper.Map<IEnumerable<PeopleViewModel>>(persons);
        }

        public async Task<PeopleViewModel> GetByIdAsync(Guid id)
        {
            var person = await _context.Peoples.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PeopleViewModel>(person);
        }

        public async Task<PeopleViewModel> AddAsync(RegisterPeopleViewModel model)
        {
            var person = _mapper.Map<People>(model);

            _context.Peoples.Add(person);
            await _context.SaveChangesAsync();

            return _mapper.Map<PeopleViewModel>(person);
        }

        public async Task<int> ImportPeopleFromCsvAsync(Stream csvStream, Guid userId)
        {
            using (var reader = new StreamReader(csvStream))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<RegisterPeopleCsvViewModel>().ToList();
                var people = _mapper.Map<List<People>>(records);

                foreach (var person in people)
                {
                    person.UserId = userId;
                }

                _context.Peoples.AddRange(people);
                await _context.SaveChangesAsync();

                return people.Count;
            }
        }

        public async Task<PeopleViewModel> UpdateAsync(UpdatePeopleViewModel model)
        {
            var person = await _context.Peoples.FirstOrDefaultAsync(x => x.Id == model.Id);

            _mapper.Map(model, person);

            _context.Peoples.Update(person);
            await _context.SaveChangesAsync();

            return _mapper.Map<PeopleViewModel>(person);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var person = await _context.Peoples.FirstOrDefaultAsync(x => x.Id == id);

            if (person is null)
                return false;

            _context.Peoples.Remove(person);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
