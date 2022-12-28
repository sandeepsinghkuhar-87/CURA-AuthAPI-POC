using System.Collections.Generic;

namespace AuthAPI.Data.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<SystemRegions> SystemRegion { get; set; }
        public List<SystemRoles> SystemRoles { get; set; }
    }
}
