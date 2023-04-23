using MinimalJwt.Models;

namespace MinimalJwt.Repositories
{
    public class UserRepository
    {
        public static List<User> Users = new()
        {
            new() {UserName = "luke_admin", EmailAddress = "luke.admin@email.com", Password ="MyPass_w0rd", GivenName= "Luke", Surname ="Roges", Role= "Administrator"},
            new() {UserName = "lydia_Standard", EmailAddress = "lydia.Standard@email.com", Password ="MyPass_w0rd", GivenName= "Lydia", Surname ="Burton", Role= "Standard"}
        };
    }
}
