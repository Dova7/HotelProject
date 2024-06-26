﻿using HotelProject.Contracts.Interfaces;
using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IManagerRepository : IBaseRepository<Manager>, IFullyUpdatable<Manager>, ISavable
    {
        
    }
}
