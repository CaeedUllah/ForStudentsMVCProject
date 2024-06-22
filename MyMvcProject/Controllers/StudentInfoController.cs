using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProjectsModels.ViewModels;
using MvcProjectsModels.MvcProjectsModels.Views;
    using MyMvcProject.ForDropDowns;
using MyMvcProject.MvcProjectsModels.Models;
using MyMvcProject.Repositories;
using MyMvcProject.ForFiles;

namespace MyMvcProject.Controllers
{
    public class StudentInfoController : Controller
    {
        private readonly IRepository<Student> StudentRepository;
        private readonly IRepository<Title> TitleRepository;
        private readonly IRepository<VStudent> VStudentRepository;
        IUnitOfWork UnitOfWork;
        IDropDownService Idropdownservice;
        IFileService IfileService;
        public StudentInfoController(IRepository<Student> studentRepository, IRepository<Title> titleRepository, IRepository<VStudent> vStudentRepository, IUnitOfWork unitOfWork, IDropDownService idropdownservice, IFileService ifileService)
            
        {
            StudentRepository = studentRepository;
            TitleRepository = titleRepository;
            VStudentRepository = vStudentRepository;
            UnitOfWork = unitOfWork;
            Idropdownservice = idropdownservice;
            IfileService = ifileService;
        }
        public IActionResult Index()
        {
            List<VStudent> vstudentsList = VStudentRepository.GetAll().ToList();
            return View(vstudentsList);
            /* StudentVM studentVM = new StudentVM();
             List<Student> studentsList = StudentRepository.GetAll().ToList();
             List<Title> titleList = TitleRepository.GetAll().ToList();

             studentVM.students = studentsList;
             studentVM.titles = titleList;
 */
            /*return View(studentVM);*/



        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TitleID = new SelectList(Idropdownservice.GetTitles(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student obj, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                if (pictureFile != null)
                {
                    obj.Image = await IfileService.UploadImageAsync(pictureFile);
                }
                StudentRepository.Add(obj);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.TitleID = new SelectList(Idropdownservice.GetTitles(), "Id", "Name");
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Student StudentFromDb = StudentRepository.Get(u => u.Id == id);
            if (StudentFromDb == null)
            {
                return NotFound();
            }
            ViewBag.TitleID = new SelectList(Idropdownservice.GetTitles(), "Id", "Name");
            return View(StudentFromDb);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student obj, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                // Fetch the current student data from the database
                var existingStudent = StudentRepository.Get(u => u.Id == obj.Id);
                if (existingStudent == null)
                {
                    // Handle the case where the student is not found
                    return NotFound();
                }

                if (imageFile != null && imageFile.Length > 0)
                {
                    obj.Image = await IfileService.UpdateImageAsync(imageFile, existingStudent.Image);
                }
                else
                {
                    // Preserve the existing image if no new image is uploaded
                    obj.Image = existingStudent.Image;
                }

                // Update the student data
                StudentRepository.update(existingStudent);
                UnitOfWork.Save();

                TempData["success"] = "Student Updated Successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                // Fetch the current student data to preserve the image on validation error
                var existingStudent = StudentRepository.Get(u => u.Id == obj.Id);
                if (existingStudent != null)
                {
                    obj.Image = existingStudent.Image;
                }

                ViewBag.TitleID = new SelectList(Idropdownservice.GetTitles(), "Id", "Name");
                return View(obj);
            }
        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Student StudentFromDb = StudentRepository.Get(u => u.Id == id);
            if (StudentFromDb == null)
            {
                return NotFound();
            }
            ViewBag.TitleID = new SelectList(Idropdownservice.GetTitles(), "Id", "Name");
            return View(StudentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Student StudentFromDb = StudentRepository.Get(u => u.Id == id);
            if (StudentFromDb == null)
            {
                return NotFound();
            }
            StudentRepository.Remove(StudentFromDb);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Student StudentFromDb = StudentRepository.Get(u => u.Id == id);
            if (StudentFromDb == null)
            {
                return NotFound();
            }
            ViewBag.TitleID = new SelectList(Idropdownservice.GetTitles(), "Id", "Name");
            return View(StudentFromDb);
        }
        [HttpGet]
        public IActionResult ModelShow()
        {
            return PartialView("ModelShow");
        }

    }
}
