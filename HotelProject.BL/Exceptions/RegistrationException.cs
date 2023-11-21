using System.Runtime.Serialization;

namespace HotelProject.BL.Model
{
    [Serializable]
    public class RegistrationException : Exception
    {


        public RegistrationException(string? message) : base(message)
        {
        }

        public RegistrationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }


    }
}