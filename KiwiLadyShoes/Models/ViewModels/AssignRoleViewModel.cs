using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KiwiLadyShoes.Models.ViewModels
{
    [Keyless]
    public class AssignRoleViewModel   //Ira,16/11/23
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
