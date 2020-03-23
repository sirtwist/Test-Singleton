using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRazorPages.Services
{
    public interface ITestService
    {
        string GetValue();

        void UpdateValue();
    }
}
