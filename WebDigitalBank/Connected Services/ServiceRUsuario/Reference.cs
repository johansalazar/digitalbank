﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDigitalBank.ServiceRUsuario {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceRUsuario.IUsuarioService")]
    public interface IUsuarioService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/CrearUsuarios", ReplyAction="http://tempuri.org/IUsuarioService/CrearUsuariosResponse")]
        void CrearUsuarios(WcfServiceDigitalBank.Models.Usuarios usuarios);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/CrearUsuarios", ReplyAction="http://tempuri.org/IUsuarioService/CrearUsuariosResponse")]
        System.Threading.Tasks.Task CrearUsuariosAsync(WcfServiceDigitalBank.Models.Usuarios usuarios);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/LeerUsuarios", ReplyAction="http://tempuri.org/IUsuarioService/LeerUsuariosResponse")]
        WcfServiceDigitalBank.Models.Usuarios LeerUsuarios(string usuariosD);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/LeerUsuarios", ReplyAction="http://tempuri.org/IUsuarioService/LeerUsuariosResponse")]
        System.Threading.Tasks.Task<WcfServiceDigitalBank.Models.Usuarios> LeerUsuariosAsync(string usuariosD);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ActualizarUsuarios", ReplyAction="http://tempuri.org/IUsuarioService/ActualizarUsuariosResponse")]
        void ActualizarUsuarios(WcfServiceDigitalBank.Models.Usuarios usuarios);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ActualizarUsuarios", ReplyAction="http://tempuri.org/IUsuarioService/ActualizarUsuariosResponse")]
        System.Threading.Tasks.Task ActualizarUsuariosAsync(WcfServiceDigitalBank.Models.Usuarios usuarios);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/EliminarUsuarios", ReplyAction="http://tempuri.org/IUsuarioService/EliminarUsuariosResponse")]
        void EliminarUsuarios(string usuariosID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/EliminarUsuarios", ReplyAction="http://tempuri.org/IUsuarioService/EliminarUsuariosResponse")]
        System.Threading.Tasks.Task EliminarUsuariosAsync(string usuariosID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/RegistrarActividad", ReplyAction="http://tempuri.org/IUsuarioService/RegistrarActividadResponse")]
        void RegistrarActividad(string accion, string tablaAfectada, string usuarios, string detalles);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/RegistrarActividad", ReplyAction="http://tempuri.org/IUsuarioService/RegistrarActividadResponse")]
        System.Threading.Tasks.Task RegistrarActividadAsync(string accion, string tablaAfectada, string usuarios, string detalles);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ListarUsuariosConPaginacion", ReplyAction="http://tempuri.org/IUsuarioService/ListarUsuariosConPaginacionResponse")]
        WcfServiceDigitalBank.Models.Usuarios[] ListarUsuariosConPaginacion(int paginaActual, int tamanoPagina);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ListarUsuariosConPaginacion", ReplyAction="http://tempuri.org/IUsuarioService/ListarUsuariosConPaginacionResponse")]
        System.Threading.Tasks.Task<WcfServiceDigitalBank.Models.Usuarios[]> ListarUsuariosConPaginacionAsync(int paginaActual, int tamanoPagina);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ObtenerTotalRegistros", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerTotalRegistrosResponse")]
        int ObtenerTotalRegistros();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ObtenerTotalRegistros", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerTotalRegistrosResponse")]
        System.Threading.Tasks.Task<int> ObtenerTotalRegistrosAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsuarioServiceChannel : WebDigitalBank.ServiceRUsuario.IUsuarioService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsuarioServiceClient : System.ServiceModel.ClientBase<WebDigitalBank.ServiceRUsuario.IUsuarioService>, WebDigitalBank.ServiceRUsuario.IUsuarioService {
        
        public UsuarioServiceClient() {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void CrearUsuarios(WcfServiceDigitalBank.Models.Usuarios usuarios) {
            base.Channel.CrearUsuarios(usuarios);
        }
        
        public System.Threading.Tasks.Task CrearUsuariosAsync(WcfServiceDigitalBank.Models.Usuarios usuarios) {
            return base.Channel.CrearUsuariosAsync(usuarios);
        }
        
        public WcfServiceDigitalBank.Models.Usuarios LeerUsuarios(string usuariosD) {
            return base.Channel.LeerUsuarios(usuariosD);
        }
        
        public System.Threading.Tasks.Task<WcfServiceDigitalBank.Models.Usuarios> LeerUsuariosAsync(string usuariosD) {
            return base.Channel.LeerUsuariosAsync(usuariosD);
        }
        
        public void ActualizarUsuarios(WcfServiceDigitalBank.Models.Usuarios usuarios) {
            base.Channel.ActualizarUsuarios(usuarios);
        }
        
        public System.Threading.Tasks.Task ActualizarUsuariosAsync(WcfServiceDigitalBank.Models.Usuarios usuarios) {
            return base.Channel.ActualizarUsuariosAsync(usuarios);
        }
        
        public void EliminarUsuarios(string usuariosID) {
            base.Channel.EliminarUsuarios(usuariosID);
        }
        
        public System.Threading.Tasks.Task EliminarUsuariosAsync(string usuariosID) {
            return base.Channel.EliminarUsuariosAsync(usuariosID);
        }
        
        public void RegistrarActividad(string accion, string tablaAfectada, string usuarios, string detalles) {
            base.Channel.RegistrarActividad(accion, tablaAfectada, usuarios, detalles);
        }
        
        public System.Threading.Tasks.Task RegistrarActividadAsync(string accion, string tablaAfectada, string usuarios, string detalles) {
            return base.Channel.RegistrarActividadAsync(accion, tablaAfectada, usuarios, detalles);
        }
        
        public WcfServiceDigitalBank.Models.Usuarios[] ListarUsuariosConPaginacion(int paginaActual, int tamanoPagina) {
            return base.Channel.ListarUsuariosConPaginacion(paginaActual, tamanoPagina);
        }
        
        public System.Threading.Tasks.Task<WcfServiceDigitalBank.Models.Usuarios[]> ListarUsuariosConPaginacionAsync(int paginaActual, int tamanoPagina) {
            return base.Channel.ListarUsuariosConPaginacionAsync(paginaActual, tamanoPagina);
        }
        
        public int ObtenerTotalRegistros() {
            return base.Channel.ObtenerTotalRegistros();
        }
        
        public System.Threading.Tasks.Task<int> ObtenerTotalRegistrosAsync() {
            return base.Channel.ObtenerTotalRegistrosAsync();
        }
    }
}