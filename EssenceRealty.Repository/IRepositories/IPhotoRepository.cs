using EssenceRealty.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EssenceRealty.Repository.IRepositories
{
    public interface IPhotoRepository : IAsyncRepository<Photo>
    {
        Task UpsertPhotos(List<Photo> lstPhoto);
        Task<List<Photo>> AddPhotos(List<Photo> lstPhotos);
    }
}
