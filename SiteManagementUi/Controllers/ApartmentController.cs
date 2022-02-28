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
        //TODO: Model alacak şekilde değiştir
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

        //[Route("ChangeApaertment/{id}")]
        public IActionResult ChangeApartment(int id)
        {
            if (id > 0)
            {
                GetApartmentModel getApartmentModel = ApartmentService.GetApartment(id);
                if (getApartmentModel != null)
                {
                    return View(getApartmentModel);

                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult ChangeApartment(GetApartmentModel apartment)
        {
            if (apartment is not null)
            {
                ChangeApartmentSenderModel apartmentSender = new ChangeApartmentSenderModel();
                apartmentSender.ApartmentType = apartment.ApartmentType;
                apartmentSender.User_Id = apartment.User_Id;
                ApartmentService.PutApartment(apartment.ApartmentId, apartmentSender);
                return View();
            }
            return View();
        }
    }
}


