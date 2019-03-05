using NewsPortal.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.ViewModel.Concrete
{
    public class NewsViewModel : IViewModel
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Guid { get; set; }

        public string Description { get; set; }

        public DateTime PubDate { get; set; }

        public string Creator { get; set; }
    }
}
