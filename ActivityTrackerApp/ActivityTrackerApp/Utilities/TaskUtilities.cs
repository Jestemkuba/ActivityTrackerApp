using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Utilities
{
    public static class TaskUtilities
    {
        public async static void Await(this Task task, Action completedCallback = null, Action<Exception> errorCallback = null)
        {
            try
            {
                await task;
                completedCallback?.Invoke();
            }
            catch (Exception ex)
            {
                errorCallback?.Invoke(ex);
            }
        }
    }
}
