using Lab5.Models;
using LabsLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Controllers
{
    public class LabsController : Controller
    {
        public IActionResult Lab1()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Lab1(L1DataModel model)
        {
            var labRunner = new L1Manager(model.X, model.K);

            try
            {
                model.Calculated = labRunner.Run();
            }
            catch (ArgumentException e)
            {
                model.ErrorValue = e.Message;
            }
            catch (Exception e)
            {
                model.ErrorValue = e.Message;
            }

            return View(model);
        }

        public IActionResult Lab2()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Lab2(L2DataModel model)
        {
            var labRunner = new L2Manager(
                model.CoinsInput.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(num => Convert.ToInt32(num)).ToArray(),
                model.SumsInput.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(num => Convert.ToInt32(num)).ToArray()
                );

            try
            {
                model.Calculated = labRunner.Run();
            }
            catch (ArgumentException e)
            {
                model.ErrorValue = e.Message;
            }
            catch (Exception e)
            {
                model.ErrorValue = e.Message;
            }

            return View(model);
        }

        public IActionResult Lab3()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Lab3(L3DataModel model)
        {
            var labRunner = new L3Manager(model.InputData.Split("\r\n", StringSplitOptions.RemoveEmptyEntries));

            try
            {
                model.Calculated = labRunner.Run();
            }
            catch (ArgumentException e)
            {
                model.ErrorValue = e.Message;
            }
            catch (Exception e)
            {
                model.ErrorValue = e.Message;
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
