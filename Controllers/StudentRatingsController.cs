using PracticeManagement.Core;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PracticeManagement.Controllers
{
    public class StudentRatingsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentRatingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var viewModel = new StudentRatingIndexViewModel
            {
                StudentRatings = _unitOfWork.StudentRatings.GetStudentRatings(),
                StudentInternships = _unitOfWork.StudentInternships.GetStudentInternships(),
                RatingTypes = _unitOfWork.RatingTypes.GetRatingTypes()
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var studentRating = _unitOfWork.StudentRatings.GetStudentRating(id);
            var student = _unitOfWork.Students.GetStudent(studentRating.StudentInternship.StudentId);
            var internship = _unitOfWork.Internships.GetInternship(studentRating.StudentInternship.InternshipId);
            var avgRating = _unitOfWork.StudentRatings.GetStudentRatings().Where(s => s.StudentInternship.StudentId == student.Id).Average(s => s.RatingType.Value);
            var viewModel = new StudentRatingDetailViewModel
            {
                StudentRating = studentRating,
                Student = student,
                StudentInternship = _unitOfWork.StudentInternships.GetStudentInternship(studentRating.StudentInternshipId),
                Internship = internship,
                AvgRating = avgRating,
                FacultyCourse = _unitOfWork.FacultyCourses.GetFacultyCourse(internship.FacultyCourseID)
            };
            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new StudentRatingFormViewModel
            {
                Internships = _unitOfWork.Internships.GetInternships().OrderBy(i => i.Name),
                RatingTypes = _unitOfWork.RatingTypes.GetRatingTypes()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentRatingFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Internships = _unitOfWork.Internships.GetInternships();
                viewModel.RatingTypes = _unitOfWork.RatingTypes.GetRatingTypes();
                return View(viewModel);
            }
            var studentRating = new StudentRating()
            {
                StudentInternshipId = viewModel.StudentInternship,
                RatingTypeId = viewModel.RatingType,
                Comment = viewModel.Comment,
                Date = DateTime.Today
            };

            _unitOfWork.StudentRatings.Add(studentRating);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentRatings");
        }

        public ActionResult Edit(int id)
        {
            var studentRating = _unitOfWork.StudentRatings.GetStudentRating(id);
            if (studentRating == null) return HttpNotFound();
            var studentIntership = _unitOfWork.StudentInternships.GetStudentInternship(studentRating.StudentInternshipId);
            var internshipId = studentIntership.InternshipId;
            var viewModel = new StudentRatingFormViewModel()
            {
                Id = studentRating.Id,
                Internships = _unitOfWork.Internships.GetInternships().Where(i => i.Id == internshipId),
                StudentInternships = _unitOfWork.StudentInternships.GetStudentInternships().Where(s => s.Id == studentIntership.Id),
                RatingType = studentRating.RatingTypeId,
                RatingTypes = _unitOfWork.RatingTypes.GetRatingTypes(),
                Comment = studentRating.Comment
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentRatingFormViewModel viewModel)
        {
            var studentRatingInDb = _unitOfWork.StudentRatings.GetStudentRating(viewModel.Id);
            studentRatingInDb.RatingTypeId = viewModel.RatingType;
            studentRatingInDb.Comment = viewModel.Comment;

            _unitOfWork.Complete();

            return RedirectToAction("Index", "StudentRatings");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var studentRating = _unitOfWork.StudentRatings.GetStudentRating(id);
            _unitOfWork.StudentRatings.Remove(studentRating);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentRatings");
        }

        [HttpPost]
        public JsonResult GetStudentInternships(int? id)
        {
            DateTime today = System.DateTime.Now.Date;

            if (id != null) {
                return Json(new SelectList(_unitOfWork.StudentInternships.GetStudentInternships()
                                        .Where(s => s.InternshipId == id && s.EndDate != null && today.Subtract(Convert.ToDateTime(s.EndDate)).TotalDays <= 20)
                                        .Where(si => !_unitOfWork.StudentRatings.GetStudentRatings()
                                        .Select(sr => sr.StudentInternshipId)
                                        .Contains(si.Id)).OrderBy(s => s.Student.Name), "Id", "Student.Name"));
            }
            else {
                return Json(new SelectList(Enumerable.Empty<SelectListItem>()));
            }
        }
    }
}
