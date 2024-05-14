using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class ChildRepository : IChildRepository
    {
        private readonly IContext _context;

        public ChildRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Child> AddAsync(Child child)
        {
            _context.Children.Add(child);
            await _context.SaveChangesAsync();
            return child;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Children.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Child>> GetAllAsync()
        {
            return await _context.Children.Include(p=>p.Parent1).Include(p => p.Parent2).
                ToListAsync();
        }

        public async Task<Child> GetByIdAsync(int id)
        {
            return await _context.Children.Include(p=>p.Parent1).Include(p => p.Parent2).
                FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<Child> UpdateAsync(Child child)
        {
            var update = _context.Children.Update(child).Entity;
            await _context.SaveChangesAsync();
            return update;
        }
    }
}
