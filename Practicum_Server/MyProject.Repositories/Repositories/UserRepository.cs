﻿using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IContext _context;

        public UserRepository(IContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            var add=_context.Users.Add(user);
            await _context.SaveChangesAsync();
            return add.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Users.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var update = _context.Users.Update(user).Entity;
            await _context.SaveChangesAsync();
            return update;
        }
    }
}
