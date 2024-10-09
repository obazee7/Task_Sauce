
namespace Task_Sauce.Secret
{
    public class Secrets
    {
        public static string userName { get; set; } = "standard_user";
        public static string password { get; set; } = "secret_sauce";
    }

    //Example2 - class file
    //initialize.SetTextToUserName(Secrets.userName);
    //initialize.SetTextToPassword(Secrets.password);


    ////Resource example
    //initialize.SetTextToUserName(ResourseSecret.username);
    //initialize.SetTextToPassword(ResourseSecret.password);
    //initialize.ClickLoginButton();
}
