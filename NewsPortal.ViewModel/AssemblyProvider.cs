using System.Reflection;

namespace NewsPortal.ViewModel
{
    public static class AssemblyProvider
    {
        public static Assembly GetAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }
    }
}
