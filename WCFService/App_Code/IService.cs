using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract]
public interface IService
{

    [OperationContract]
    string SayHello(string name);

    [OperationContract]
    User GetUserById(int id);  

    [OperationContract]
    List<User> GetAllUsers();

    [OperationContract]
    void AddUser(User user);

    [OperationContract]
    [WebGet(UriTemplate = "/hello/{name}", ResponseFormat = WebMessageFormat.Json)]
    string SayHelloJson(string name);

    [OperationContract]
    [WebGet(UriTemplate = "/users", ResponseFormat = WebMessageFormat.Json)]
    List<User> GetAllUsersJson();

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/adduser/json",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json)]
    User AddUserJson(User user);
}