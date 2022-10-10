﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoanApplicationWCFService.Models
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoanModel", Namespace="http://schemas.datacontract.org/2004/07/LoanApplicationWCFService.Models")]
    public partial class LoanModel : object
    {
        private System.Guid CustomerIdField;
        
        private bool IsActiveField;
        
        private decimal LoanAmountField;
        
        private string LoanApprovedDateField;
        
        private System.Guid LoanIdField;
        
        private int LoanTenureField;
        
        private string LoanTypeField;
        
        
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid CustomerId
        {
            get
            {
                return this.CustomerIdField;
            }
            set
            {
                this.CustomerIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsActive
        {
            get
            {
                return this.IsActiveField;
            }
            set
            {
                this.IsActiveField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal LoanAmount
        {
            get
            {
                return this.LoanAmountField;
            }
            set
            {
                this.LoanAmountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LoanApprovedDate
        {
            get
            {
                return this.LoanApprovedDateField;
            }
            set
            {
                this.LoanApprovedDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid LoanId
        {
            get
            {
                return this.LoanIdField;
            }
            set
            {
                this.LoanIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LoanTenure
        {
            get
            {
                return this.LoanTenureField;
            }
            set
            {
                this.LoanTenureField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LoanType
        {
            get
            {
                return this.LoanTypeField;
            }
            set
            {
                this.LoanTypeField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ILoanService")]
public interface ILoanService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/AddLoan", ReplyAction="http://tempuri.org/ILoanService/AddLoanResponse")]
    void AddLoan(LoanApplicationWCFService.Models.LoanModel loan);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/AddLoan", ReplyAction="http://tempuri.org/ILoanService/AddLoanResponse")]
    System.Threading.Tasks.Task AddLoanAsync(LoanApplicationWCFService.Models.LoanModel loan);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/UpdateLoan", ReplyAction="http://tempuri.org/ILoanService/UpdateLoanResponse")]
    void UpdateLoan(LoanApplicationWCFService.Models.LoanModel loan, System.Guid id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/UpdateLoan", ReplyAction="http://tempuri.org/ILoanService/UpdateLoanResponse")]
    System.Threading.Tasks.Task UpdateLoanAsync(LoanApplicationWCFService.Models.LoanModel loan, System.Guid id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/DeleteLoan", ReplyAction="http://tempuri.org/ILoanService/DeleteLoanResponse")]
    void DeleteLoan(System.Guid id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/DeleteLoan", ReplyAction="http://tempuri.org/ILoanService/DeleteLoanResponse")]
    System.Threading.Tasks.Task DeleteLoanAsync(System.Guid id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/GetAllLoans", ReplyAction="http://tempuri.org/ILoanService/GetAllLoansResponse")]
    LoanApplicationWCFService.Models.LoanModel[] GetAllLoans();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/GetAllLoans", ReplyAction="http://tempuri.org/ILoanService/GetAllLoansResponse")]
    System.Threading.Tasks.Task<LoanApplicationWCFService.Models.LoanModel[]> GetAllLoansAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/GetLoanById", ReplyAction="http://tempuri.org/ILoanService/GetLoanByIdResponse")]
    LoanApplicationWCFService.Models.LoanModel GetLoanById(System.Guid Id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/GetLoanById", ReplyAction="http://tempuri.org/ILoanService/GetLoanByIdResponse")]
    System.Threading.Tasks.Task<LoanApplicationWCFService.Models.LoanModel> GetLoanByIdAsync(System.Guid Id);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ILoanServiceChannel : ILoanService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class LoanServiceClient : System.ServiceModel.ClientBase<ILoanService>, ILoanService
{
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
    public LoanServiceClient(string endPointAddress) :
        base(LoanServiceClient.GetDefaultBinding(), LoanServiceClient.GetDefaultEndpointAddress(endPointAddress))
    {
        this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ILoanService.ToString();
        ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
    }
    
    public LoanServiceClient(EndpointConfiguration endpointConfiguration, string endPointAddress) :
             base(LoanServiceClient.GetBindingForEndpoint(endpointConfiguration), LoanServiceClient.GetEndpointAddress(endpointConfiguration, endPointAddress))
    {
        this.Endpoint.Name = endpointConfiguration.ToString();
        ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
    }

    public LoanServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) :
            base(LoanServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
    {
        this.Endpoint.Name = endpointConfiguration.ToString();
        ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
    }

    
    public LoanServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LoanServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public void AddLoan(LoanApplicationWCFService.Models.LoanModel loan)
    {
        base.Channel.AddLoan(loan);
    }
    
    public System.Threading.Tasks.Task AddLoanAsync(LoanApplicationWCFService.Models.LoanModel loan)
    {
        return base.Channel.AddLoanAsync(loan);
    }
    
    public void UpdateLoan(LoanApplicationWCFService.Models.LoanModel loan, System.Guid id)
    {
        base.Channel.UpdateLoan(loan, id);
    }
    
    public System.Threading.Tasks.Task UpdateLoanAsync(LoanApplicationWCFService.Models.LoanModel loan, System.Guid id)
    {
        return base.Channel.UpdateLoanAsync(loan, id);
    }
    
    public void DeleteLoan(System.Guid id)
    {
        base.Channel.DeleteLoan(id);
    }
    
    public System.Threading.Tasks.Task DeleteLoanAsync(System.Guid id)
    {
        return base.Channel.DeleteLoanAsync(id);
    }
    
    public LoanApplicationWCFService.Models.LoanModel[] GetAllLoans()
    {
        return base.Channel.GetAllLoans();
    }
    
    public System.Threading.Tasks.Task<LoanApplicationWCFService.Models.LoanModel[]> GetAllLoansAsync()
    {
        return base.Channel.GetAllLoansAsync();
    }
    
    public LoanApplicationWCFService.Models.LoanModel GetLoanById(System.Guid Id)
    {
        return base.Channel.GetLoanById(Id);
    }
    
    public System.Threading.Tasks.Task<LoanApplicationWCFService.Models.LoanModel> GetLoanByIdAsync(System.Guid Id)
    {
        return base.Channel.GetLoanByIdAsync(Id);
    }

    private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
    {
        if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ILoanService))
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

    private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration, string endPointAddress)
    {
        if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ILoanService))
        {

            return new System.ServiceModel.EndpointAddress(endPointAddress);
        }
        throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
    }

    private static System.ServiceModel.Channels.Binding GetDefaultBinding()
    {
        return LoanServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ILoanService);
    }

    private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress(string endPointAddress)
    {
        return LoanServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ILoanService, endPointAddress);
    }


    public enum EndpointConfiguration
    {

        BasicHttpBinding_ILoanService,
    }
}
