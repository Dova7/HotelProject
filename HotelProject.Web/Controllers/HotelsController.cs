using HotelProject.Models;
using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
	public class HotelsController : Controller
	{
		private readonly HotelRepository _hotelRepository;
		public HotelsController()
		{
			_hotelRepository = new HotelRepository();
		}

		public async Task<IActionResult> Index()
		{
			var result = await _hotelRepository.GetHotels();
			return View(result);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Hotel model)
		{
			await _hotelRepository.AddHotel(model);
			return RedirectToAction("Index");
		}
        public IActionResult DeleteConf(int id)
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _hotelRepository.DeleteHotel(id);
			return RedirectToAction("Index");
		}
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Update(Hotel model)
		{
			await _hotelRepository.UpdateHotel(model);
			return RedirectToAction("Index");
		}
	}
}
