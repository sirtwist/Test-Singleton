using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestRazorPages.Services
{
    public class TestService : ITestService
    {
        private static string _value;
        public string GetValue()
        {
            return _value;
        }

        private async Task<string> UpdateValueWithCurrentTime()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return DateTime.Now.ToString();
        }

        private void UpdateValueWrapper()
        {
            var t = UpdateValueWithCurrentTime().GetAwaiter();

            try
            {
                _value = t.GetResult();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                    Debug.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
        }


        public void UpdateValue()
        {
            UpdateValueWrapper();
        }

        public TestService()
        {
            UpdateValueWrapper();
        }

    }
}
