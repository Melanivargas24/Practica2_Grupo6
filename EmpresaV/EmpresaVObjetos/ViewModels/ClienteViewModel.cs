﻿

namespace EmpresaVObjetos.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public List<TelefonoViewModel> Telefonos { get; set; } = new();
    }

  
}
