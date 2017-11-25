using System;
namespace Laboratorio1Cenfotec.Model
{
    public class LoginModel
    {
        public string User { get; set; }
        public string Password { get; set; }

        public LoginModel()
        {
        }

        public static bool Auntenticar(string user, string password)
        {

            bool ans = false;

            if (user == "carlos" && password == "123")
                ans = true;

            return ans;
        }
    }
}
