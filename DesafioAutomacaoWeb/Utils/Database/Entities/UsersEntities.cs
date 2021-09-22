using DesafioAutomacaoWeb.Utils.Database.Enum;

namespace DesafioAutomacaoWeb.Utils.Entities
{
    public class UsersEntities
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public bool ProtectedUser { get; set; }
        public UserAccessLevel AccessLevel { get; set; }
        public int LoginCount { get; set; }
        public int LostPasswordRequestCount { get; set; }
        public int FailedLoginCount { get; set; }
        public string CookieString { get; set; }
        public int LastVisit { get; set; }
        public int DateCreated { get; set; }
    }
}