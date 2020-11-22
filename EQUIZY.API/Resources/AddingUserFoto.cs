using EQUIZY.API.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class AddingUserFoto
    {
        [PesoArchivoValidacion(PesoMaxMB: 40)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile Image { get; set; }
    }
}
