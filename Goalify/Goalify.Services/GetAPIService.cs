using Goalify.Common.Models;
using Refit;

namespace Goalify.Services
{
    public interface GetAPIService
    {
        [Get("/objects")]
        Task<List<Root>> GetData();
    }

}
