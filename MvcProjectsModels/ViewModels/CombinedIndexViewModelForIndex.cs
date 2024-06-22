using MyMvcProject.MvcProjectsModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectsModels.ViewModels
{
    public class CombinedIndexViewModelForIndex
    {
        public List<a> RecordsA { get; set; }
        public List<b> RecordsB { get; set; }
    }
    public class CombinedRecord
    {
        public List<CombinedIndexViewModelForIndex> combinedIndexViewModelForIndices { get; set; }
    }
}
