﻿using HotelProject.Models;
using HotelProject.Repository.MVCRepos;

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
        public async Task Return_All_Managers_From_DB()
        {
            var result = await _managerRepository.GetManagers();
        }
        [Fact]
        public async Task Add_New_Manager_To_DB()
        {
            Manager newManager = new Manager()
            {
                FirstName = "Giorgi",
                SecondName = "Gujarelidze",
                HotelId = null
            };

            await _managerRepository.AddManager(newManager);
        }
        [Fact]
        public async Task Update_Manager_In_DB()
        {
            Manager updatedManager = new Manager()
            {
                Id = 1,
                FirstName = "Irakli",
                SecondName = "Gujarelidze",
                HotelId = null
            };
            await _managerRepository.UpdateManager(updatedManager);
        }
        [Fact]
        public async Task Delete_Manager_In_DB()
        {
            await _managerRepository.DeleteManager(6);
        }
        [Fact]
        public async Task Get_Single_Manager_By_Id()
        {
            await _managerRepository.GetManagerById(1);
        }
    }
}
