using HotelProject.Data;
using HotelProject.Models;
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
		private readonly ApplicationDBContext _context;
        public ManagersController(IManagerRepository managerRepository, IHotelRepository hotelRepository, ApplicationDBContext context)
		{
			_managerRepository = managerRepository;
            _hotelRepository = hotelRepository;
			_context = context;
        }
		public async Task<IActionResult> Index()
        {
			var result = await _managerRepository.GetAllAsync(includePropeties: "Hotel");
            return View(result);
        }
		public async Task<IActionResult> Create()
		{
            var hotels = await _hotelRepository.GetAllAsync(x=>x.Manager == null);
            ViewBag.HotelId = new SelectList(hotels, "Id", "HotelName");
            return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Manager model)
		{
			await _managerRepository.AddAsync(model);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		public IActionResult DeleteConf(int id)
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _managerRepository.GetAsync(x=>x.Id == id, includePropeties: "Hotel");
			if (result != null)
			{
				_managerRepository.Remove(result);
			}
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
		}
		public async Task<IActionResult> Update(int id)
		{
			var hotels = await _hotelRepository.GetAllAsync(x => x.Manager == null);
			var manager = await _managerRepository.GetAsync(x => x.Id == id, includePropeties: "Hotel");
			if (manager != null)
			{
				if (manager.HotelId.HasValue)
				{
					var currentHotel = await _hotelRepository.GetAsync(x => x.Id == manager.HotelId.Value);
					if(currentHotel != null)
					{ 
					hotels.Add(currentHotel);
                    }
                }
			}
            ViewBag.HotelId = new SelectList(hotels, "Id", "HotelName");			
            return View(manager);
		}
		[HttpPost]
		public async Task<IActionResult> Update(Manager model)
		{
			await _managerRepository.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
		}
	}
}
