﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vista.ServiceReferenceUF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceUF.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/suma", ReplyAction="http://tempuri.org/IService1/sumaResponse")]
        int suma(int p1, int p2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/suma", ReplyAction="http://tempuri.org/IService1/sumaResponse")]
        System.Threading.Tasks.Task<int> sumaAsync(int p1, int p2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UF", ReplyAction="http://tempuri.org/IService1/UFResponse")]
        double UF();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UF", ReplyAction="http://tempuri.org/IService1/UFResponse")]
        System.Threading.Tasks.Task<double> UFAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Vista.ServiceReferenceUF.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Vista.ServiceReferenceUF.IService1>, Vista.ServiceReferenceUF.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int suma(int p1, int p2) {
            return base.Channel.suma(p1, p2);
        }
        
        public System.Threading.Tasks.Task<int> sumaAsync(int p1, int p2) {
            return base.Channel.sumaAsync(p1, p2);
        }
        
        public double UF() {
            return base.Channel.UF();
        }
        
        public System.Threading.Tasks.Task<double> UFAsync() {
            return base.Channel.UFAsync();
        }
    }
}
