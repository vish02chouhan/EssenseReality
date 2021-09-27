using EssenceRealty.Repository.IRepositories;
using EssenseReality.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Scheduler.ServiceProcessors
{
    public class SuburbProcessor
    {
        public async Task ProcessSubhurbMasterData(IServiceProvider serviceProvider, JArray items)
        {
            try
            {
                var lstSubHurbs = JsonConvert.DeserializeObject<IList<Suburb>>(items.ToString())
                                  .Where(x => x != null && x.Id > 0).ToList()
                                  .Select<Suburb, Suburb>(p => new Suburb
                                  {
                                      Id = 0,
                                      Name = p.Name,
                                      CrmSuburbId = p.Id,
                                      Postcode = p.Postcode,
                                      StateId = 0,
                                      State = new State()
                                      {
                                          Id = 0,
                                          Name = p.State.Name,
                                          CrmStateId = p.State.Id,
                                          Abbreviation = p.State.Abbreviation,
                                          CreatedBy = "SuburbProcessor",
                                          CreatedDate = DateTime.Now,
                                          ModifiedDate = DateTime.Now,
                                          ModifieldBy = "SuburbProcessor"
                                      },
                                      CreatedBy = "SuburbProcessor",
                                      CreatedDate = DateTime.Now,
                                      ModifiedDate = DateTime.Now,
                                      ModifieldBy = "SuburbProcessor"
                                  }).ToList();

                var lstStates = lstSubHurbs.Select(x => x.State)
                            .Where(x => x != null && x.CrmStateId > 0).ToList()
                            .GroupBy(elem => elem.CrmStateId)
                            .Select(group => group.First()).ToList();

                using var scope = serviceProvider.CreateScope();
                var stateRepo = scope.ServiceProvider.GetRequiredService<IStateRepository>();
                await stateRepo.UpsertStates(lstStates);
                var subhurbRepo = scope.ServiceProvider.GetRequiredService<ISubhurbRepository>();
                await subhurbRepo.UpsertSubhurbs(lstSubHurbs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
