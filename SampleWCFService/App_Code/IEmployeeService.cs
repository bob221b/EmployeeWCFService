using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for IEmployeeService
/// </summary>
[ServiceContract]
public interface IEmployeeService
{
    [OperationContract]
    string GetData();
    
}
[DataContract]
public class EmployeeData
{
    [DataMember]
    public string dumptable { get; set; }
}