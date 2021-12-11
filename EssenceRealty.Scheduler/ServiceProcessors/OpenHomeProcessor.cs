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
    public class OpenHomeProcessor
    {
        public async Task ProcessOpenHomeData(IServiceProvider serviceProvider, JArray items, int crmPropertyId)
        {
            try
            {
                List<OpenHome> lstOpenHome = new();

                foreach (var item in items)
                {
                    dynamic data = JsonConvert.DeserializeObject(item.ToString());
                    if (data != null)
                    {
                        OpenHome objOpenHome = ExtractOpenHomeData(item);
                        lstOpenHome.Add(objOpenHome);
                    }
                }

                using var scope = serviceProvider.CreateScope();
                await UpsertOpenHomeData(scope, lstOpenHome, crmPropertyId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public OpenHome ExtractOpenHomeData(JToken item)
        {
            JsonProcessor<OpenHome> objJsonProcessor = new();
            OpenHome objOpenHome = (OpenHome)objJsonProcessor.ExtractData<OpenHome>(item);
            objOpenHome.CrmOpenHomeId = objOpenHome.Id;
            objOpenHome.Id = 0;
            objOpenHome.CreatedBy = ERConstants.OPEN_HOME_PRROCESSOR;
            objOpenHome.ModifieldBy = ERConstants.OPEN_HOME_PRROCESSOR;
            return objOpenHome;
        }


        private async Task UpsertOpenHomeData(IServiceScope scope, List<OpenHome> lstOpenHome, int crmPropertyId)
        {
            var openHomeRepo = scope.ServiceProvider.GetRequiredService<IOpenHomeRepository>();
            await openHomeRepo.UpsertOpenHome(lstOpenHome.Select(x => x)
                        .Where(x => x != null).ToList()
                        .GroupBy(elem => elem.CrmOpenHomeId)
                        .Select(group => group.First()).ToList(), crmPropertyId);
        }
    }
}
