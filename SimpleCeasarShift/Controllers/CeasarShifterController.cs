using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SimpleCeasarShift.Controllers
{
    public class CeasarShifterController : Controller
    {
        //
        // GET: /CeasarShifter/
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(string inputString, string encrypt)
        {
            if (encrypt == "encrypt")
            {
                var shiftAmount = 3;
                ShiftCipher shifter = new ShiftCipher();
                var outputString = shifter.Encrypt(inputString, shiftAmount);
                ViewBag.outputString = outputString;
                return View();
            }
            else
            {
                var shiftAmount = -3;
                ShiftCipher shifter = new ShiftCipher();
                var outputString = shifter.Decrypt(inputString, shiftAmount);
                ViewBag.outputString = outputString;
                return View();
            }
        }

    }
}
