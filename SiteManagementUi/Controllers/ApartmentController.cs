using Microsoft.AspNetCore.Mvc;
using SiteManagementUi.Models.ApartmentModels;
using SiteManagementUi.Services;
using System.Collections.Generic;

namespace SiteManagementUi.Controllers
{
    public class ApartmentController : Controller
    {
        public IActionResult GetAllApartment()
        {
            List<GetApartmentModel> getApartmentModel = ApartmentService.GetAllApartments();
            return View(getApartmentModel);
        }
        public IActionResult AddApartment(string apartmentBlock, int apartmentFloor, int apartmentNo, string apartmentType)
        {
            if (apartmentBlock is null) { return View(); }

            AddApartmentModel apartmentModel = new AddApartmentModel();
            apartmentModel.ApartmentBlock = apartmentBlock;
            apartmentModel.ApartmentFloor = apartmentFloor;
            apartmentModel.ApartmentNo = apartmentNo;
            apartmentModel.ApartmentType = apartmentType;
            ApartmentService.PostApartment(apartmentModel);
            return View();
        }

        public IActionResult ChangeApartment(string apartmentBlock, int apartmentFloor, int apartmentNo, string apartmentType, int user_Id)
        {
            if (apartmentBlock is null) { return View(); }

            ChangeApartmentSenderModel apartmentModel = new ChangeApartmentSenderModel();
            apartmentModel.ApartmentType = apartmentType;
            apartmentModel.User_Id = user_Id;
            ApartmentService.PutApartment(apartmentBlock, apartmentFloor, apartmentNo, apartmentModel);
            return View();
        }
    }
}


