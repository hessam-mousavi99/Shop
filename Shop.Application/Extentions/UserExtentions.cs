using Shop.Application.DTOs.Accounts;
using Shop.Domain.Models.Account;

namespace Shop.Application.Extentions
{
    public static class UserExtentions
    {
        public static string GetUserName(this User user)
        {
            //vaghti k mikhahim nam ra dar user panel khode karbar edit konad.
            //if(!string.IsNullOrWhiteSpace(user.FirstName)&& !string.IsNullOrWhiteSpace(user.LastName))
            //{
            //    return $"{user.FirstName} {user.LastName}";
            //}
            //return user.PhoneNumber;

            //vaghti nam ra dar hengam sabte nam grftim.
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
