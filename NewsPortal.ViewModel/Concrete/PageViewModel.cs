using NewsPortal.ViewModel.Base;
using System.Collections.Generic;

namespace NewsPortal.ViewModel.Concrete
{
    public class PageViewModel<TViewModel>
        where TViewModel : IViewModel
    {
        public IEnumerable<TViewModel> Items { get; set; }

        public int Count { get; set; }
    }
}
