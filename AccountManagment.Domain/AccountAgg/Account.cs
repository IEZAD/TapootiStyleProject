using Microsoft.AspNetCore.Identity;
using AccountManagment.Domain.RoleAgg;

namespace AccountManagment.Domain.AccountAgg
{
    public class Account : IdentityUser
    {
        public Role Role { get; private set; }

        public string RoleId { get; private set; }

        public string CountryCode { get; private set; }

        public virtual ICollection<FileManagement.Domain.FileAgg.File> Files { get; private set; }

        protected Account()
        {

        }

        public Account(string roleId, string countryCode, string phoneNumber, string userName)
        {
            RoleId = roleId;
            UserName = userName;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
            NormalizedUserName = userName.ToUpper();
        }

        public Account(string id, string roleId, string countryCode, string phoneNumber, string userName, bool phoneNumberConfirmed)
        {
            Id = id;
            RoleId = roleId;
            UserName = userName;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
            NormalizedUserName = userName.ToUpper();
            PhoneNumberConfirmed = phoneNumberConfirmed;
        }

        public void Update(string userName, string countryCode, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(userName))
                UserName = userName;
            if (!string.IsNullOrEmpty(countryCode) && !string.IsNullOrEmpty(phoneNumber))
            {
                CountryCode = countryCode;
                PhoneNumber = phoneNumber;
                PhoneNumberConfirmed = false;
            }
        }

        public void Update(string roleId, string userName, string countryCode, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(roleId))
                RoleId = roleId;
            if (!string.IsNullOrEmpty(userName))
                UserName = userName;
            if(!string.IsNullOrEmpty(countryCode) && !string.IsNullOrEmpty(phoneNumber))
            {
                CountryCode = countryCode;
                PhoneNumber = phoneNumber;
                PhoneNumberConfirmed = false;
            }
        }
    }
}