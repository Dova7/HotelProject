using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MVCRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHotelRepository _hotelRepository;
        public RoomsController(IRoomRepository roomRepository, IHotelRepository hotelRepository)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _roomRepository.GetRooms();
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.HotelId = new SelectList(hotels, "Id", "HotelName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Room model)
        {
            await _roomRepository.AddRoom(model);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteConf(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomRepository.DeleteRoom(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update()
        {
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.HotelId = new SelectList(hotels, "Id", "HotelName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Room model)
        {
            await _roomRepository.UpdateRoom(model);
            return RedirectToAction("Index");
        }
    }
}
