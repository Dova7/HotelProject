﻿using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository.EFRepos
{
    public class HotelRepositoryEF : IHotelRepository
    {
        private readonly ApplicationDBContext _context;
        public HotelRepositoryEF(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task AddHotel(Hotel hotel)
        {
            if (hotel == null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            _context.Hotels.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            var entity = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            return entity;

        }

        public async Task<List<Hotel>> GetHotels()
        {
            var entities = await _context.Hotels.ToListAsync();

            if (entities == null)
            {
                throw new NullReferenceException("Entities not found");
            }

            return entities;

        }

        public async Task<List<Hotel>> GetHotelsWithoutManager()
        {
            var entities = await _context.Hotels
                .Where(x => x.Manager == null)
                .ToListAsync();

            return entities;
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            if (hotel == null || hotel.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == hotel.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.HotelName = hotel.HotelName;
            entity.Rating = hotel.Rating;
            entity.Country = hotel.Country;
            entity.City = hotel.City;
            entity.PhysicalAddress = hotel.PhysicalAddress;

            _context.Hotels.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
