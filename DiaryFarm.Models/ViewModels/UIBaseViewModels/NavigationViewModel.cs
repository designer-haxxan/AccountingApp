using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryFarm.Models.ViewModels.UIBaseViewModels
{
    public class NavigationViewModel
    {
        public string? Title { get; set; }
        public List<string>? Links { get; set; }
    }
}
