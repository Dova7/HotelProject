using HotelProject.Models;
using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class ManagersController : Controller
    {
		private readonly ManagerRepository _managerRepository;
		public ManagersController()
		{
			_managerRepository = new ManagerRepository();
		}
		public async Task<IActionResult> Index()
        {
			var result = await _managerRepository.GetManagers();
            return View(result);
        }
		public IActionResult Create()
		{
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
		public IActionResult Update()
		{
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
