﻿using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MVCRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace HotelProject.Web.Controllers
{
    public class ManagersController : Controller
    {
		private readonly IManagerRepository _managerRepository;
		private readonly IHotelRepository _hotelRepository;
        public ManagersController(IManagerRepository managerRepository, IHotelRepository hotelRepository)
		{
			_managerRepository = managerRepository;
            _hotelRepository = hotelRepository;
        }
		public async Task<IActionResult> Index()
        {
			var result = await _managerRepository.GetManagers();
            return View(result);
        }
		public async Task<IActionResult> Create()
		{
            var hotels = await _hotelRepository.GetHotelsWithoutManager();
            ViewBag.HotelId = new SelectList(hotels, "Id", "HotelName");
            return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Manager model)
		{
			await _managerRepository.AddManager(model);
			return RedirectToAction("Index");
		}
		public IActionResult DeleteConf(int id)
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _managerRepository.DeleteManager(id);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Update(int id)
		{
			var hotels = await _hotelRepository.GetHotelsWithoutManager();
			var manager = await _managerRepository.GetManagerById(id);
			if (manager.HotelId.HasValue)
			{
				var currentHotel = await _hotelRepository.GetHotelById(manager.HotelId.Value);
                hotels.Add(currentHotel);
            }
            ViewBag.HotelId = new SelectList(hotels, "Id", "HotelName");			
            return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(Manager model)
		{
			await _managerRepository.UpdateManager(model);
			return RedirectToAction("Index");
		}
	}
}
