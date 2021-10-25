using System.Collections.Generic;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.IRepositories
{
    public interface IAsyncSearch<T1,T2> where T1 : class where T2 : class
    {
        Task<IEnumerable<T1>> SearchAsync(T2 entity);
    }
}
