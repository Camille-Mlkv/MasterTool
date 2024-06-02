using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MasterTool.UI.Services
{
    public static class CredentialsChecker
    {
        public static bool IsPasswordValid(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Регулярное выражение для проверки пароля
            var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(password);
        }

        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;

            // Регулярное выражение для проверки номера телефона
            var regex = new Regex(@"^\+375(25|44|29)\d{7}$");
            return regex.IsMatch(phoneNumber);
        }

        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@(gmail\.com|mail\.ru)$");
            return regex.IsMatch(email);
        }
    }
}
