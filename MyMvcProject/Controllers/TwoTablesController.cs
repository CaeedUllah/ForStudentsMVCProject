using Microsoft.AspNetCore.Mvc;
using MvcProjectsModels.MvcProjectsModels.Views;
using MvcProjectsModels.ViewModels;
using MyMvcProject.MvcProjectsModels.Models;
using MyMvcProject.Repositories;

namespace MyMvcProject.Controllers
{
    public class TwoTablesController : Controller
    {
        private readonly IRepository<a> ARepository;
        private readonly IRepository<b> BRepository;
        private readonly IRepository<VCombined> VCombinedRepository;
        private readonly IRepository<VMaAndb> VMCombinedRepository;
        IUnitOfWork UnitOfWork;
        public TwoTablesController(IRepository<VCombined> vCombinedRepository, IUnitOfWork unitOfWork, IRepository<a> aRepository, IRepository<b> bRepository, IRepository<VMaAndb> vMCombinedRepository)
        {
            VCombinedRepository = vCombinedRepository;
            UnitOfWork = unitOfWork;
            ARepository = aRepository;
            BRepository = bRepository;
            VMCombinedRepository = vMCombinedRepository;
        }
        public IActionResult Index()
        {
            List<VCombined> Vlist = VCombinedRepository.GetAll().ToList();
            return View(Vlist);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VMaAndb obj)
        {
            /*// method one
            if (ModelState.IsValid)
            {
                // Functional style: Create and add entity for Table A
                _aRepository.Add(new a
                {
                    NameForA = obj.ForA.NameForA,
                    AddressForA = obj.ForA.AddressForA
                });

                // Functional style: Create and add entity for Table B
                _bRepository.Add(new b
                {
                    NameForB = obj.ForB.NameForB,
                    AddressForB = obj.ForB.AddressForB
                });

                _unitOfWork.Save(); // Save changes to the database

                return RedirectToAction("Index"); // Redirect on successful save
            }*/
            if (ModelState.IsValid)
            {
                // Create instance of Table A entity
                var entityA = new a
                {
                    NameForA = obj.ForA.NameForA,
                    AddressForA = obj.ForA.AddressForA
                };

                // Add entityA to ARepository
                ARepository.Add(entityA);

                // Create instance of Table B entity
                var entityB = new b
                {
                    NameForB = obj.ForB.NameForB,
                    AddressForB = obj.ForB.AddressForB
                };

                // Add entityB to BRepository
                BRepository.Add(entityB);

                // Save changes using UnitOfWork
                UnitOfWork.Save();
                TempData["success"] = "Catgory Created Successfully !";

                // Redirect to Index action after successful save
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, return the view with validation errors
            return View(obj);
        }

    }
}
