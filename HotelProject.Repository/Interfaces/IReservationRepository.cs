using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservations();
        public Task<Reservation> GetSingleReservation(int id);
        public Task AddReservation(Reservation Reservation);
        public Task UpdateReservation(Reservation Reservation);
        public Task DeleteReservation(int id);
    }
}
