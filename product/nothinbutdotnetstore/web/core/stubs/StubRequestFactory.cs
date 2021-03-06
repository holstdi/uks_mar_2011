using System.Web;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext the_current_context)
        {
            return new StubRequest(the_current_context.Request.RawUrl);
        }

        class StubRequest : Request
        {
            public StubRequest(string url)
            {
                this.url = url;
            }


            public InputModel map<InputModel>()
            {
                object item = new Department();
                return (InputModel) item;
            }

            public string url { get; private set; }
        }
    }
}