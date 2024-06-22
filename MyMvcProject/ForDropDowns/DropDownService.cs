using MyMvcProject.MvcProjectsModels.Models;
using MyMvcProject.Repositories;

namespace MyMvcProject.ForDropDowns
{
    public class DropDownService : IDropDownService
    {
        private readonly IRepository<Title> TitleRepository;
        public DropDownService(IRepository<Title> titleRepository) 
        {
           TitleRepository = titleRepository;
        }
        public List<Title> GetTitles()
        {
            return TitleRepository.GetAll().OrderBy(aa => aa.Name).ToList();
        }
    }
}
