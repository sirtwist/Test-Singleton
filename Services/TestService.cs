using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestRazorPages.Services
{
    public class TestService: ITestService
    {
        private static string _value;
        public string GetValue()
        {
            return _value;
        }

        public TestService()
        {
            CancellationTokenSource source = new CancellationTokenSource();

            var t = Task.Run(async delegate
            {
                // replace these two lines with your async call and returning the resulting string.
                await Task.Delay(TimeSpan.FromSeconds(10), source.Token);
                return "value that you derived from your async call";
            });
            try
            {
               _value = t.Result;
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                    Debug.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.Write("Task t Status: {0}", t.Status);
            if (t.Status == TaskStatus.RanToCompletion)
                Debug.Write(", Result: {0}", t.Result);
            source.Dispose();
        }

    }
}
