using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
	[OperationContract]
	bool testconnection();

	[OperationContract]
	List<user> getUsers();

	[OperationContract]
	bool InsertUser(user newUser);

    [OperationContract]
    bool UpdateUser(user newUser);

    [OperationContract]
    bool DeleteUser(Int64 id);
}



public enum Role
{
    Admin,
    Operator
}

[DataContract]
public class user
{
    [DataMember]
    public Int64 id { get; set; }
    [DataMember]
    public string username { get; set; }
    [DataMember]
    public string password { get; set; }
    [DataMember]
    public Role role { get; set; }
}
