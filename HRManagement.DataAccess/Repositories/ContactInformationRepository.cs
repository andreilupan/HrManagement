//using HRManagement.DataAccess.Models.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HRManagement.DataAccess.Repositories
//{
//    public class ContactInformationRepository
//    {
//        private HrContext _dbContext;
//        public ContactInformationRepository(HrContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public void CreateContactInformation(int employeeId, string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail)
//        {
//            var user = _dbContext.Employees.Find(employeeId);

//            var contactInformation = new ContactInformation
//            {
//                Address = address,
//                City = city,
//                PostalCode = postalCode,
//                State = state,
//                PrivateEmail = privateEmail,
//                PrivatePhone = privatePhone,
//                WorkEmail = workEmail,
//                WorkPhone = workPhone
//            };

//            user.ContactInformation = contactInformation;
//            _dbContext.SaveChanges();
//        }
//    }
//}
