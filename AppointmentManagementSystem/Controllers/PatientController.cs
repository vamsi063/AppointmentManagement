using Infrastructure.IRespositories;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppointmentManagementSystem.ViewModel;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace AppointmentManagementSystem.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly AppDbContext _appDbContext;

        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(AppDbContext appDbContext, IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: PatientController
        public ActionResult Index()
        {
            var patients = _unitOfWork.Patients.GetPatients();
            return View(patients);
        }

        public ActionResult Details(int id)
        {
            var viewModel = new PatientDetailViewModel()
            {
                Patient = _unitOfWork.Patients.GetPatient(id),
                Appointments = _unitOfWork.Appointments.GetAppointmentWithPatient(id),
                CountAppointments = _unitOfWork.Appointments.CountAppointments(id),
            };
            return View("Details", viewModel);
        }

        [Authorize]
        // GET: PatientController/Create
        public ActionResult Create()
        {
            var viewModel = new PatientFormViewModel
            {
                Cities = _unitOfWork.Cities.GetCities(),
                Heading = "New Patient"
            };
            return View("PatientForm", viewModel);
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientFormViewModel viewModel)
        {
            try
            {
                ModelState.Remove("Cities");
                ModelState.Remove("Heading");
                if (!ModelState.IsValid)
                {
                    viewModel.Cities = _unitOfWork.Cities.GetCities();
                    viewModel.Heading = "New Patient";
                    return View("PatientForm", viewModel);

                }

                var patient = new Patient
                {
                    Name = viewModel.Name,
                    Phone = viewModel.Phone,
                    Address = viewModel.Address,
                    DateTime = DateTime.Now,
                    BirthDate = viewModel.GetBirthDate(),
                    Height = viewModel.Height,
                    Weight = viewModel.Weight,
                    CityId = viewModel.City,
                    Sex = viewModel.Sex,
                    Token = (2018 + _patientRepository.GetPatients().Count()).ToString().PadLeft(7, '0')
                };

                _patientRepository.Add(patient);
                _unitOfWork.Complete();
                return RedirectToAction("Index", "Patient");
            }
            catch
            {
                return View();
            }
        }



        // GET: PatientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
