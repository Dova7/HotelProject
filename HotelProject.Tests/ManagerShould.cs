using HotelProject.Models;
using HotelProject.Repository;

namespace HotelProject.Tests
{
    public class ManagerShould
    {
        private readonly ManagerRepository _managerRepository;
        public ManagerShould()
        {
            _managerRepository = new();
        }
        [Fact]
        public void Return_All_Managers_From_DB()
        {
            var result = _managerRepository.GetManagers();
        }
        [Fact]
        public void Add_New_Manager_To_DB()
        {
            Manager newManager = new Manager()
            {
                FirstName = "Giorgi",
                SecondName = "Gujarelidze"
            };

            _managerRepository.AddManager(newManager);
        }
        [Fact]
        public void Update_Manager_In_DB()
        {
            Manager updatedManager = new Manager()
            {
                Id = 1,
                FirstName = "Irakli",
                SecondName = "Gujarelidze"
            };
            _managerRepository.UpdateManager(updatedManager);
        }
        [Fact]
        public void Delete_Manager_In_DB()
        {
            _managerRepository.DeleteManager(7);
        }
    }
}
