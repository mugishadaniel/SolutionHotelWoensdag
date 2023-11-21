using HotelProject.BL.Interfaces;
using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BL.Managers
{
    public class RegistrationManager
    {
        private IRegistrationRepository registrationRepository;
        public RegistrationManager(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }
        public void AddRegistration(Registration registration)
        {
            registrationRepository.AddRegistration(registration);
        }

        public List<Registration> GetAllRegistrations()
        {
            return registrationRepository.GetAllRegistrations();
        }
    }
}
