using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Cliente
    {
        String documento;
        String nombre;
        int tipoDocumento;

        public enum TipoDocumento: int {dni=1, cuit=2, cuil=3, le=4, lc=5}

        public Cliente(TipoDocumento docTipo, String documento, String nombre)
        {
            this.documento = documento;
            this.nombre = nombre;
            this.tipoDocumento = (int) docTipo;
        }

        public TipoDocumento TipoDeDocumento { get { return (TipoDocumento) this.tipoDocumento; } }
        public String Nombre { get { return this.nombre; } }
        public String Documento { get { return this.documento; } }
    }
}
