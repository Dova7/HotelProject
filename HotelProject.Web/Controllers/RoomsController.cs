using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository;
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
        private readonly ApplicationDBContext _context;
        public RoomsController(IRoomRepository roomRepository, IHotelRepository hotelRepository, ApplicationDBContext context)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _roomRepository.GetAllAsync(includePropeties: "Hotel");
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            var hotels = await _hotelRepository.GetAllAsync();
            ViewBag.HotelId = new SelectList(hotels, "Id", "HotelName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Room model)
        {
            await _roomRepository.AddAsync(model);
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
            var result = await _roomRepository.GetAsync(x => x.Id == id, includePropeties: "Hotel");

            if (result != null)
            {
                _roomRepository.Remove(result);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update()
        {
            var hotels = await _hotelRepository.GetAllAsync();
            ViewBag.HotelId = new SelectList(hotels, "Id", "HotelName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Room model)
        {
            await _roomRepository.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
