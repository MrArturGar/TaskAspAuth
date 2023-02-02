using Newtonsoft.Json;
using System.Security.Principal;
using TestTaskAuth.Models;
using WSDL_Lib;

namespace TestTaskAuth.Services
{
    public class ApiClient
    {
        IICUTech _provider;

        public string ResponseText;
        public ApiClient()
        {
            _provider = new ICUTechClient();
        }

        public bool CreateNewCustomer(string email, string login, string firstName, string lastName, string mobile, int countryId, int aId, string signupIp)
        {
            var request = new RegisterNewCustomerRequest(email, login, firstName, lastName, mobile, countryId, aId, signupIp);

            var response = _provider.RegisterNewCustomerAsync(request).GetAwaiter().GetResult();
            if (IsPositiveResult(response.@return))
            { 
                return true;
            }
            return false;

        }

        public Detail? Auth(Credential credential)
        {
            var request = new LoginRequest(credential.Username, credential.Password, "");
            var response = _provider.LoginAsync(request).GetAwaiter().GetResult();
            if (IsPositiveResult(response.@return))
            {
                return JsonConvert.DeserializeObject<Detail>(response.@return);
            }
            return null;
        }
        public bool IsPositiveResult(string result)
        {
            ResponseText = String.Empty;
            ResultApi? resultApi = JsonConvert.DeserializeObject<ResultApi>(result);

            ResponseText = resultApi.ResultMessage;

            if (resultApi.ResultCode == 0)
                return true;
            else if (resultApi.ResultCode == 1)
                return true;
            else
                return false;
        }
    }
}
