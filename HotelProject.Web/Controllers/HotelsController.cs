using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly ApplicationDBContext _context;
        public HotelsController(IHotelRepository hotelRepository, ApplicationDBContext context)
        {
            _hotelRepository = hotelRepository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _hotelRepository.GetAllAsync();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Hotel model)
        {
            await _hotelRepository.AddAsync(model);
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
            var result = await _hotelRepository.GetAsync(x => x.Id == id);

            if (result != null)
            {
                _hotelRepository.Remove(result);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var hotel = await _hotelRepository.GetAsync(x => x.Id == id);
            return View(hotel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Hotel model)
        {

            await _hotelRepository.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
