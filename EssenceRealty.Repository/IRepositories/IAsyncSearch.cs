using System.Collections.Generic;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.IRepositories
{
    public interface IAsyncSearch<T1,T2, T3> where T1 : class where T3 : class
    {
        Task<(IEnumerable<T1>, T2)> SearchAsync(T3 entity,int page, int size);

        //Task<(IEnumerable<Property>, int)> SearchAsync(PropertySearchRequest propertySearchRequestViewModel, int page, int size)
    }
}
