using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

static class CheckDataService
{
    public static void CheckUserData(string email, string password, string confirmPassword)
    {
        if (password != confirmPassword)
            throw new ArgumentException("Password mismatch!");

        if (!RegexCollection.PasswordRegex.IsMatch(password))
            throw new ArgumentException("Wrong password! \n The password must contain letters, numbers and symbols and be at least 8 characters long.");

        if (!RegexCollection.EmailRegex.IsMatch(email))
            throw new ArgumentException("Wrong Email! \n The email should be like \"example@gmail.com\" ");
        
    }
}
