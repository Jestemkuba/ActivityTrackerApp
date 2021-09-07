using ActivityTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Services.Contracts
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetActivities();

        Task SyncStravaActivities(string stravaToken);

        Task<Activity> AddActivity(Activity activity);
    }
}
