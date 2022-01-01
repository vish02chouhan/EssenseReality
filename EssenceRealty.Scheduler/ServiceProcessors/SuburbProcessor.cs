using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Domain.Models;
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
    public class SuburbsProcessor:IProcessEssence
    {
        private readonly IServiceProvider serviceProvider;
        public SuburbsProcessor(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task ProcessJsonData(CrmEssenceLog objCrmEssenceLog)
        {
            var items = JArray.Parse(objCrmEssenceLog.JsonObjectBatch);
            try
            {
                var lstSubHurbs = ExtractSuburbStateData(items);
                using var scope = serviceProvider.CreateScope();
                await UpsertStateData(scope, lstSubHurbs);
                await UpsertSubhurbData(scope, lstSubHurbs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public List<Suburb> ExtractSuburbStateData(JArray items)
        {
            return JsonConvert.DeserializeObject<IList<Suburb>>(items.ToString())
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
                                          CreatedBy = ERConstants.SUBURB_PROCESSOR,
                                          CreatedDate = DateTime.Now,
                                          ModifiedDate = DateTime.Now,
                                          ModifieldBy = ERConstants.SUBURB_PROCESSOR
                                      },
                                      CreatedBy = ERConstants.SUBURB_PROCESSOR,
                                      CreatedDate = DateTime.Now,
                                      ModifiedDate = DateTime.Now,
                                      ModifieldBy = ERConstants.SUBURB_PROCESSOR
                                  }).ToList();
        }
        public async Task UpsertStateData(IServiceScope scope, List<Suburb> lstSubHurbs)
        {
            var lstStates = lstSubHurbs.Select(x => x.State)
                           .Where(x => x != null && x.CrmStateId > 0).ToList()
                           .GroupBy(elem => elem.CrmStateId)
                           .Select(group => group.First()).ToList();

            var stateRepo = scope.ServiceProvider.GetRequiredService<IStateRepository>();
            await stateRepo.UpsertStates(lstStates);
        }
        public async Task UpsertSubhurbData(IServiceScope scope, List<Suburb> lstSubHurbs)
        {
            var subhurbRepo = scope.ServiceProvider.GetRequiredService<ISubhurbRepository>();
            await subhurbRepo.UpsertSubhurbs(lstSubHurbs.GroupBy(elem => elem.CrmSuburbId).Select(group => group.First()).ToList());
        }
    }
}
