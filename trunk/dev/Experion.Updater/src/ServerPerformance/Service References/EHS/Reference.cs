﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerPerformance.EHS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/Experion.HealthService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MachineMemoryInfo", Namespace="http://schemas.datacontract.org/2004/07/Experion.HealthService.Dto")]
    [System.SerializableAttribute()]
    public partial class MachineMemoryInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal AvailablePhysicalMemoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal FreeMemoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MachineNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal OccupiedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TotalMemoryField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal AvailablePhysicalMemory {
            get {
                return this.AvailablePhysicalMemoryField;
            }
            set {
                if ((this.AvailablePhysicalMemoryField.Equals(value) != true)) {
                    this.AvailablePhysicalMemoryField = value;
                    this.RaisePropertyChanged("AvailablePhysicalMemory");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal FreeMemory {
            get {
                return this.FreeMemoryField;
            }
            set {
                if ((this.FreeMemoryField.Equals(value) != true)) {
                    this.FreeMemoryField = value;
                    this.RaisePropertyChanged("FreeMemory");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MachineName {
            get {
                return this.MachineNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MachineNameField, value) != true)) {
                    this.MachineNameField = value;
                    this.RaisePropertyChanged("MachineName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Occupied {
            get {
                return this.OccupiedField;
            }
            set {
                if ((this.OccupiedField.Equals(value) != true)) {
                    this.OccupiedField = value;
                    this.RaisePropertyChanged("Occupied");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TotalMemory {
            get {
                return this.TotalMemoryField;
            }
            set {
                if ((this.TotalMemoryField.Equals(value) != true)) {
                    this.TotalMemoryField = value;
                    this.RaisePropertyChanged("TotalMemory");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MachineProcessInfo", Namespace="http://schemas.datacontract.org/2004/07/Experion.HealthService.Dto")]
    [System.SerializableAttribute()]
    public partial class MachineProcessInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MachineNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServerPerformance.EHS.ProcessInfo[] ProcessInfosField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MachineName {
            get {
                return this.MachineNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MachineNameField, value) != true)) {
                    this.MachineNameField = value;
                    this.RaisePropertyChanged("MachineName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServerPerformance.EHS.ProcessInfo[] ProcessInfos {
            get {
                return this.ProcessInfosField;
            }
            set {
                if ((object.ReferenceEquals(this.ProcessInfosField, value) != true)) {
                    this.ProcessInfosField = value;
                    this.RaisePropertyChanged("ProcessInfos");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessInfo", Namespace="http://schemas.datacontract.org/2004/07/Experion.HealthService.Dto")]
    [System.SerializableAttribute()]
    public partial class ProcessInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long WorkingSetField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long WorkingSet {
            get {
                return this.WorkingSetField;
            }
            set {
                if ((this.WorkingSetField.Equals(value) != true)) {
                    this.WorkingSetField = value;
                    this.RaisePropertyChanged("WorkingSet");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EHS.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        ServerPerformance.EHS.CompositeType GetDataUsingDataContract(ServerPerformance.EHS.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ServerPerformance.EHS.CompositeType> GetDataUsingDataContractAsync(ServerPerformance.EHS.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ServerPerformance.EHS.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ServerPerformance.EHS.IService1>, ServerPerformance.EHS.IService1 {
        
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
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public ServerPerformance.EHS.CompositeType GetDataUsingDataContract(ServerPerformance.EHS.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<ServerPerformance.EHS.CompositeType> GetDataUsingDataContractAsync(ServerPerformance.EHS.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EHS.IHealthService")]
    public interface IHealthService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHealthService/GetMemoryUsage", ReplyAction="http://tempuri.org/IHealthService/GetMemoryUsageResponse")]
        ServerPerformance.EHS.MachineMemoryInfo GetMemoryUsage();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHealthService/GetMemoryUsage", ReplyAction="http://tempuri.org/IHealthService/GetMemoryUsageResponse")]
        System.Threading.Tasks.Task<ServerPerformance.EHS.MachineMemoryInfo> GetMemoryUsageAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHealthService/GetAllMemoryStatics", ReplyAction="http://tempuri.org/IHealthService/GetAllMemoryStaticsResponse")]
        ServerPerformance.EHS.MachineProcessInfo GetAllMemoryStatics();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHealthService/GetAllMemoryStatics", ReplyAction="http://tempuri.org/IHealthService/GetAllMemoryStaticsResponse")]
        System.Threading.Tasks.Task<ServerPerformance.EHS.MachineProcessInfo> GetAllMemoryStaticsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHealthServiceChannel : ServerPerformance.EHS.IHealthService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HealthServiceClient : System.ServiceModel.ClientBase<ServerPerformance.EHS.IHealthService>, ServerPerformance.EHS.IHealthService {
        
        public HealthServiceClient() {
        }
        
        public HealthServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HealthServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HealthServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HealthServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ServerPerformance.EHS.MachineMemoryInfo GetMemoryUsage() {
            return base.Channel.GetMemoryUsage();
        }
        
        public System.Threading.Tasks.Task<ServerPerformance.EHS.MachineMemoryInfo> GetMemoryUsageAsync() {
            return base.Channel.GetMemoryUsageAsync();
        }
        
        public ServerPerformance.EHS.MachineProcessInfo GetAllMemoryStatics() {
            return base.Channel.GetAllMemoryStatics();
        }
        
        public System.Threading.Tasks.Task<ServerPerformance.EHS.MachineProcessInfo> GetAllMemoryStaticsAsync() {
            return base.Channel.GetAllMemoryStaticsAsync();
        }
    }
}
