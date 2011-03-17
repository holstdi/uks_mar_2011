using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public delegate ReportModel ViewRepositoryQuery<ReportModel>(Request request);

    public delegate ViewRepositoryQuery<ReportModel> ViewRepositoryQueryFactory<ReportModel>();
}