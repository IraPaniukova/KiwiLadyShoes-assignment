using Microsoft.EntityFrameworkCore;

namespace KiwiLadyShoes.Models.ViewModels
{
    [Keyless]
    public class EditRoleViewModel  //Ira,16/11/23
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
