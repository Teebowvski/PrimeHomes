using PayPal.Api;
using System.Collections.Generic;

namespace PrimeHomes.Paypal
{
    public class PaypalConfiguration
    {
        //Variables for storing the clientID and clientSecret key
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        //Constructor
        static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["AXZ_1iZA4Xcgbqp__g5mCvgKZbDHXMUcxqlywx0dboMt1C2_fb0ax2P0hG0actgNBNE_IS2c1zEW8iCO"];
            ClientSecret = config["EJfwRBMFfkrOTnIb_ZwKp4RDyE_gjINBEQExTMb64-Bk3uu8iAp1nuyOs2Dr135PkrQyqOJZg1ka-s7J"];
        }

        // getting properties from the web.config
        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            // getting accesstocken from paypal               
            string accessToken = new OAuthTokenCredential
        (ClientId, ClientSecret, GetConfig()).GetAccessToken();

            return accessToken;
        }

        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}
