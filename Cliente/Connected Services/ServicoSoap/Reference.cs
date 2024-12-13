﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicoSoap
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/")]
    public partial class CompositeType : object, System.ComponentModel.INotifyPropertyChanged
    {
        
        private bool BoolValueField;
        
        private string StringValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue
        {
            get
            {
                return this.BoolValueField;
            }
            set
            {
                if ((this.BoolValueField.Equals(value) != true))
                {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue
        {
            get
            {
                return this.StringValueField;
            }
            set
            {
                if ((object.ReferenceEquals(this.StringValueField, value) != true))
                {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="user", Namespace="http://schemas.datacontract.org/2004/07/")]
    public partial class user : object, System.ComponentModel.INotifyPropertyChanged
    {
        
        private int idField;
        
        private string passwordField;
        
        private string roleField;
        
        private string usernameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                if ((this.idField.Equals(value) != true))
                {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                if ((object.ReferenceEquals(this.passwordField, value) != true))
                {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                if ((object.ReferenceEquals(this.roleField, value) != true))
                {
                    this.roleField = value;
                    this.RaisePropertyChanged("role");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.usernameField, value) != true))
                {
                    this.usernameField = value;
                    this.RaisePropertyChanged("username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicoSoap.IService")]
    public interface IService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        ServicoSoap.CompositeType GetDataUsingDataContract(ServicoSoap.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ServicoSoap.CompositeType> GetDataUsingDataContractAsync(ServicoSoap.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUsers", ReplyAction="http://tempuri.org/IService/GetUsersResponse")]
        ServicoSoap.user[] GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUsers", ReplyAction="http://tempuri.org/IService/GetUsersResponse")]
        System.Threading.Tasks.Task<ServicoSoap.user[]> GetUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Addusers", ReplyAction="http://tempuri.org/IService/AddusersResponse")]
        ServicoSoap.user[] Addusers(ServicoSoap.user user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Addusers", ReplyAction="http://tempuri.org/IService/AddusersResponse")]
        System.Threading.Tasks.Task<ServicoSoap.user[]> AddusersAsync(ServicoSoap.user user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/testconnection", ReplyAction="http://tempuri.org/IService/testconnectionResponse")]
        bool testconnection();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/testconnection", ReplyAction="http://tempuri.org/IService/testconnectionResponse")]
        System.Threading.Tasks.Task<bool> testconnectionAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IServiceChannel : ServicoSoap.IService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ServicoSoap.IService>, ServicoSoap.IService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServiceClient() : 
                base(ServiceClient.GetDefaultBinding(), ServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ServiceClient.GetBindingForEndpoint(endpointConfiguration), ServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public string GetData(int value)
        {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value)
        {
            return base.Channel.GetDataAsync(value);
        }
        
        public ServicoSoap.CompositeType GetDataUsingDataContract(ServicoSoap.CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<ServicoSoap.CompositeType> GetDataUsingDataContractAsync(ServicoSoap.CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public ServicoSoap.user[] GetUsers()
        {
            return base.Channel.GetUsers();
        }
        
        public System.Threading.Tasks.Task<ServicoSoap.user[]> GetUsersAsync()
        {
            return base.Channel.GetUsersAsync();
        }
        
        public ServicoSoap.user[] Addusers(ServicoSoap.user user)
        {
            return base.Channel.Addusers(user);
        }
        
        public System.Threading.Tasks.Task<ServicoSoap.user[]> AddusersAsync(ServicoSoap.user user)
        {
            return base.Channel.AddusersAsync(user);
        }
        
        public bool testconnection()
        {
            return base.Channel.testconnection();
        }
        
        public System.Threading.Tasks.Task<bool> testconnectionAsync()
        {
            return base.Channel.testconnectionAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:63283/Service.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IService,
        }
    }
}
