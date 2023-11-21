using HotelProject.BL.Interfaces;
using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BL.Managers
{
    public class ActivityManager : IActivityRepository
    {
        private IActivityRepository _activityRepository;

        public ActivityManager(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public void AddActivity(Activity activity)
        {
            _activityRepository.AddActivity(activity);
        }


        public List<Activity> GetActivities(string filter)
        {
            return _activityRepository.GetActivities(filter);
        }

        public void UpdateActivityAvailableSeats(Activity activity,int seats)
        {
            _activityRepository.UpdateActivityAvailableSeats(activity,seats);
        }
    }
}
