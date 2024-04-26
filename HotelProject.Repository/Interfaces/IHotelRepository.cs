﻿using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IHotelRepository : IBaseRepository<Hotel>, IFullyUpdatable<Hotel>
    {
        
    }
}
