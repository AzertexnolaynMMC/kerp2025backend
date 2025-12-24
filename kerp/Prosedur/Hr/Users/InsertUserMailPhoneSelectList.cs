using kerp.Prosedur.Hr.Users.Mail;
using kerp.Prosedur.Hr.Users.Phone;
using kerp.Prosedur.Hr.Users.User;

namespace kerp.Prosedur.Hr.Users
{
    public class InsertUserMailPhoneSelectList
    {
        public UserSelectAdmin? UserSelectAdmin { get; set; }

        public List<UserSelectMail>? UserSelectMail { get; set; }
        public List<UserSelectPhone>? UserSelectPhone { get; set; }
    }
}
/*
 * 
 * 
 
Mene backendden gelen ve gedenleri yazmisam.
buna uygun mene Istifadeci idare etmesi yaz ver.
sertler var.
user insert dialogu acilanda 
*/