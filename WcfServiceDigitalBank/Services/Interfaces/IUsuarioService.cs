using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceDigitalBank.Models;

namespace WcfServiceDigitalBank.Services.Interfaces
{
    [ServiceContract]

    public interface IUsuarioService
    {
        [OperationContract]
        void CrearUsuarios(Usuarios usuarios);

        [OperationContract]
        Usuarios LeerUsuarios(string usuariosD);

        [OperationContract]
        void ActualizarUsuarios(Usuarios usuarios);

        [OperationContract]
        void EliminarUsuarios(string usuariosID);

        [OperationContract]
        void RegistrarActividad(string accion, string tablaAfectada, string usuarios, string detalles);

        [OperationContract]
        List<Usuarios> ListarUsuariosConPaginacion(int paginaActual, int tamanoPagina);
        [OperationContract]
        int ObtenerTotalRegistros();

    }
}
