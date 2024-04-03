using HotelProject.Models;
using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomRepository _roomRepository;
        public RoomsController()
        {
            _roomRepository = new RoomRepository();
        }
        public async Task<IActionResult> Index()
        {
            var result = await _roomRepository.GetRooms();
            return View(result);
        }
        public IActionResult Create()
        {
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
        public IActionResult Update()
        {
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
