namespace ProjektniZadatak.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
            {
                    new UserModel(){ Username="vanja",Password="vanja_admin",Role="Admin"}
            };
    }
}
