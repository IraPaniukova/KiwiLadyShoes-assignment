using Microsoft.EntityFrameworkCore;

namespace KiwiLadyShoes.Models.ViewModels
{
    [Keyless]
    public class CreateRoleViewModel  //Ira,16/11/23
    {
        public string RoleName { get; set; }
    }
}
