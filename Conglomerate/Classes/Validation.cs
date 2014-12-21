using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conglomerate.Classes
{
    public class Validation
    {
        public bool isValidNum(string data)
        {
            string pattern = "^([0-9]+)$";

            if (!string.IsNullOrEmpty(data) && System.Text.RegularExpressions.Regex.IsMatch(data, pattern))
                return true;
            else
                return false;
        }

        public bool isValidAlphaNum(string data)
        {
            string pattern = "^([a-zA-Z0-9]+)$";
            if (!string.IsNullOrEmpty(data) && System.Text.RegularExpressions.Regex.IsMatch(data, pattern))
                return true;
            else
                return false;
        }

        public bool isValidAlpha(string data)
        {
            string pattern = "^([a-zA-Z]+)$";
            if (!string.IsNullOrEmpty(data) && System.Text.RegularExpressions.Regex.IsMatch(data, pattern))
                return true;
            else
                return false;
        }

        public bool isValidFilename(string data)
        {
            string pattern = "^[*].(jpg|bmp|gif)$";
            if (!string.IsNullOrEmpty(data) && System.Text.RegularExpressions.Regex.IsMatch(data, pattern))
                return true;
            else
                return false;
        }
        public bool isValidText(string data)
        {
            string pattern = "^([a-zA-Z0-9.\\ ?\\-]+)$";
            if (!string.IsNullOrEmpty(data) && System.Text.RegularExpressions.Regex.IsMatch(data, pattern))
                return true;
            else
                return false;
        }

        public bool isValidEmail(string data)
        {
            string pattern = "^([a-z]{1})([a-z0-9_.]+)@([0-9a-z-]+).([a-z.]{2,8})$";
            if (!string.IsNullOrEmpty(data) && System.Text.RegularExpressions.Regex.IsMatch(data, pattern))
                return true;
            else
                return false;
        }

        public bool isValidUsername(string data)
        {
            string pattern = "^([a-z]{1})([a-z0-9_.]{5,14})$";
            if (!string.IsNullOrEmpty(data) && System.Text.RegularExpressions.Regex.IsMatch(data, pattern))
                return true;
            else
                return false;
        }

        public bool isValidPassword(string data)
        {
            if (!string.IsNullOrEmpty(data) &&
                System.Text.RegularExpressions.Regex.IsMatch(data, "[a-z]") &&
                System.Text.RegularExpressions.Regex.IsMatch(data, "[A-Z]") &&
                System.Text.RegularExpressions.Regex.IsMatch(data, "[0-9]") &&
                System.Text.RegularExpressions.Regex.IsMatch(data, "[@.#$%^&]") &&
                data.Length > 7
                )
                return true;
            else
                return false;
        }

        public bool isValidContact(string data)
        {
            string pattern = "^([0-9]{10})$";
            if (!string.IsNullOrEmpty(data) && System.Text.RegularExpressions.Regex.IsMatch(data, pattern))
                return true;
            else
                return false;
        }
    }
}