﻿using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IReservationRepository : IBaseRepository<Reservation>, IFullyUpdatable<Reservation>
    {
        
    }
}
