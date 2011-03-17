using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewAReportModel<ReportModel> : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        StoreCatalog general_catalog;
        readonly ViewRepositoryQueryFactory<ReportModel> query_factory;

        public ViewAReportModel(ViewRepositoryQueryFactory<ReportModel> query_factory) : this(new WebFormRenderer(),
                                                        Stub.with<StubStoreCatalog>(), query_factory )
        {
        }

        public ViewAReportModel(RenderingGateway rendering_gateway,
                                               StoreCatalog catalog, ViewRepositoryQueryFactory<ReportModel> query_factory)
        {
            this.rendering_gateway = rendering_gateway;
            this.general_catalog = catalog;
            this.query_factory = query_factory;
        }

        public void process(Request request)
        {
            rendering_gateway.render(query_factory()(request));
        }
    }
}