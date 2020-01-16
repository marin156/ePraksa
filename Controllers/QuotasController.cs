using PracticeManagement.Core;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeManagement.Controllers
{
    [Authorize(Roles = RoleName.FirmaAdminRoleName + "," + RoleName.AdministratorRoleName)]
    public class QuotasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuotasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var Quotas = _unitOfWork.Quotas.GetQuotas();
            return View(Quotas);
        }

        public ActionResult Create()
        {
            var viewModel = new QuotaFormViewModel
            {
                Heading = "New Quota",
                Faculties = _unitOfWork.Faculties.GetFaculties(),
                PracticeTypes = _unitOfWork.PracticeTypes.GetPracticeTypes()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuotaFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                viewModel.PracticeTypes = _unitOfWork.PracticeTypes.GetPracticeTypes();
                return View(viewModel);

            }
            var quota = new Quota()
            {
                DateFrom = viewModel.GetDateFrom(),
                DateTo = viewModel.GetDateTo(),
                StudentAmount = int.Parse(viewModel.Amount),
                Activated = true,
                ComapnyId = 1,
                Description = viewModel.Description,
                CollegeId = viewModel.Faculty,
                TypeId = viewModel.PracticeType

        };

            _unitOfWork.Quotas.Add(quota);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Quotas");
        }

        public ActionResult Edit(int id)
        {
            var quota = _unitOfWork.Quotas.GetQuota(id);
            var viewModel = new QuotaFormViewModel()
            {
                Heading = "Edit Quota",
                Id = quota.Id,
                DateFrom = quota.DateFrom.ToString("dd/MM/yyyy"),
                DateTo = quota.DateTo.ToString("dd/MM/yyyy"),
                Amount = quota.StudentAmount.ToString(),
                Status = quota.Activated,
                Description = quota.Description,
                Faculty = quota.Faculty.Id,
                Faculties = _unitOfWork.Faculties.GetFaculties(),
                PracticeType = quota.TypeId,
                PracticeTypes = _unitOfWork.PracticeTypes.GetPracticeTypes()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuotaFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                viewModel.PracticeTypes = _unitOfWork.PracticeTypes.GetPracticeTypes();
                return View(viewModel);
            }

            var quotaInDb = _unitOfWork.Quotas.GetQuota(viewModel.Id);
            quotaInDb.Id = viewModel.Id;
            quotaInDb.DateFrom = viewModel.GetDateFrom();
            quotaInDb.DateTo = viewModel.GetDateTo();
            quotaInDb.StudentAmount = int.Parse(viewModel.Amount);
            quotaInDb.Description = viewModel.Description;
            quotaInDb.Activated = viewModel.Status;
            quotaInDb.CollegeId = viewModel.Faculty;
            quotaInDb.TypeId = viewModel.PracticeType;
            quotaInDb.ComapnyId = 1;
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Quotas");

        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var quota = _unitOfWork.Quotas.GetQuota(id);
            _unitOfWork.Quotas.Remove(quota);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Quotas");
        }

    [HttpPost]
    public ActionResult ToggleStatus(int id)
    {
        var quota = _unitOfWork.Quotas.GetQuota(id);
        quota.Activated = !quota.Activated;
        _unitOfWork.Complete();
        return RedirectToAction("Index", "Quotas");
    }
}
}