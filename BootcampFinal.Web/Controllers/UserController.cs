using System;
using System.Threading.Tasks;
using BootcampFinal.Application.Interfaces;
using BootcampFinal.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace BootcampFinal.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {

            var users = _userService.GetAllUser();

            return View(users);
        }


        public IActionResult Create()
        {
            return View();

        }

        [HttpPost, ActionName("Create")]
        public IActionResult Create(User user)
        {

            user.RegisterTime = DateTime.Now;
            _userService.Add(user);

            return RedirectToAction("Index");
        }


        /// Kullanıcı Silme İşlemi

        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return View(user);
            }
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _userService.Delete(user);
            }

            return RedirectToAction("Index");
        }

        /// Kullanıcı Güncelleme İşlemi

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return View(user);
            }
        }


        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                await TryUpdateModelAsync(user);
                _userService.Update(user);
            }
            return RedirectToAction("Index");
        }

        [ActionName("UpdateStatus")]
        public IActionResult UpdateIsActive(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _userService.UpdateIsActive(user);
            }

            return RedirectToAction("Index");
        }

    }
}
