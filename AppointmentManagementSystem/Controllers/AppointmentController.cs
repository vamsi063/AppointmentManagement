using AppointmentManagementSystem.ViewModel;
using Domain;
using Infrastructure;
using Infrastructure.IRespositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: AppointmentManagementSystem

        private readonly AppDbContext _appDbContext;

        private readonly IAppointmentRepository _appointmentRepository;

        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(AppDbContext appDbContext, IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var appointments = _unitOfWork.Appointments.GetAppointments();
            return View(appointments);
        }

        // GET: AppointmentManagementSystem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppointmentManagementSystem/Create
        public ActionResult Create(int id)
        {
            var viewModel = new AppointmentFormViewModel
            {
                Patient = id,
                Doctors = _unitOfWork.Doctors.GetAvailableDoctors(),

                Heading = "New Appointment"
            };
            return View(viewModel);
        }

        // POST: AppointmentManagementSystem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentFormViewModel viewModel)
        {
            try
            {
                ModelState.Remove("Patients");
                ModelState.Remove("Doctors");
                ModelState.Remove("Heading");
                ModelState.Remove("Appointments");
                if (!ModelState.IsValid)
                {
                    viewModel.Doctors = _unitOfWork.Doctors.GetAvailableDoctors();
                    return View(viewModel);

                }
                var appointment = new Appointment()
                {
                    StartDateTime = viewModel.GetStartDateTime(),
                    Detail = viewModel.Detail,
                    Status = false,
                    PatientId = viewModel.Patient,
                    Doctor = _unitOfWork.Doctors.GetDoctor(viewModel.Doctor)

                };
                //Check if the slot is available
                if (_unitOfWork.Appointments.ValidateAppointment(appointment.StartDateTime, viewModel.Doctor))
                    return View("InvalidAppointment");

                _unitOfWork.Appointments.Add(appointment);
                _unitOfWork.Complete();
                return RedirectToAction("Index", "Appointment");
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentManagementSystem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AppointmentManagementSystem/Edit/5
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

        // GET: AppointmentManagementSystem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppointmentManagementSystem/Delete/5
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
