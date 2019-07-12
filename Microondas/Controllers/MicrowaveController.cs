using Microondas.Models;
using Microondas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microondas.Controllers
{
    public class MicrowaveController : Controller
    {
        private readonly IMicrowaveService _service;

        public MicrowaveController(IMicrowaveService service)
        {
            _service = service;
        }

        public async Task<IActionResult> PreHeating()
        {
            return View( _service.GetPreHeating());
        }


        public IActionResult Heat()
        {
            return View();
        }

        public IActionResult FastHeat()
        {
            return FastHeat(new PreHeating());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Heat([Bind("Id,KeyText,Second,Power")] PreHeating microwave)
        {
            _service.Heat(microwave);
            return View("ModalResponse");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FastHeat(PreHeating microwave)
        {
            _service.FastHeat(microwave);
            return View("ModalResponse");
        }
    }
}