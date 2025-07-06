using System;
using System.Collections.Generic;


namespace EmpresaVObjetos.Modelos
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public List<Telefono> Telefonos { get; set; } = new();
    }

}
