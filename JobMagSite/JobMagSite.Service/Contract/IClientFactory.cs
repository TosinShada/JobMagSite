using System.Threading.Tasks;

namespace JobMagSite.Service.Contract
{
    public interface IClientFactory
    {
        Task<SampleResponse> PostDataAsync<SampleResponse, SampleRequest>(string endPoint, SampleRequest dto);
        Task<SampleResponse> GetDataAsync<SampleResponse>(string endPoint);
    }
}
