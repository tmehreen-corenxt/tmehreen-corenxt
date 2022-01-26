using coreNXTProtoV1.Shared;

namespace coreNXTProtoV1.Client.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<TopLevelMenu>> GetTopLevelMenu(int localeid, int parentcategoryid);

    }
}
