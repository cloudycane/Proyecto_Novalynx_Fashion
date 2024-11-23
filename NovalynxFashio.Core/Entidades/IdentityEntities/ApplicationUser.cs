using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NovalynxFashion.Core.Enums;

namespace NovalynxFashion.Core.Entidades.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? NombreCompleto { get; set; }
        public int? Edad {  get; set; }
        public RoleEnum? Role { get; set; }
        public string? Biografía { get; set; }
        public string? Direccion { get; set; }
        public string? LinkedIn { get; set; }
        public bool? HaAsistido { get; set; }
        public DateTime? HoraDeEntrada { get; set; }
        public DateTime? HoraDeSalida { get; set; }
        public string? ImageProfile { get; set; }
    
    }
}
