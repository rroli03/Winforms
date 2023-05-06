using Hotcakes.CommerceDTO.v1.Client;

namespace Hotcakes_orders
{
    //Az eredeti Api osztályt kellett bővíteni egy IApi interface-vel,
    //hogy felcserélhető legyen a TestableApi-val, ami szintén ezt az interface-t implementálja.
    public class ApiImplementation : Api, IApi
    {
        public ApiImplementation(string baseWebSiteUri, string apiKey) : base(baseWebSiteUri, apiKey)
        {
        }
    }
}
