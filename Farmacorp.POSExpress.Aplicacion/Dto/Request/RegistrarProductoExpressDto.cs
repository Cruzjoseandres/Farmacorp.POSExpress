using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Farmacorp.POSExpress.Aplicacion.Dto.Request
{
    public class RegistrarProductoExpressDto
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateTime FechaVencimiento { get; set; }


        //opcionales
        [Required(ErrorMessage = "El tipo de producto es obligatorio.")]
        public int IdTipoProducto { get; set; }
        public string Observaciones { get; set; }
 
    }
}
