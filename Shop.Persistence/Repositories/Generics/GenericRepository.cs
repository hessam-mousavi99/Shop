﻿using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Shop.Persistence.Repositories.Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopDBContext _context;
        public GenericRepository(ShopDBContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State= EntityState.Modified;
            await _context.SaveChangesAsync();  
        }
    }
}