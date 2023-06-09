﻿using EssenceRealty.Repository.IRepositories;
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
    public class PropertyFeaturesProcessor
    {
        public async Task ProcessPropertyFeaturesData(IServiceProvider serviceProvider, JArray items, int propertyId)
        {
            try
            {
                List<PropertyFeatureGrouping> lstPropertyFeatureGrouping = new();
                List<PropertyFeature> lstPropertyFeature = new();

                foreach (var item in items)
                {
                    if (item != null && item["groupName"] != null)
                    {
                        PropertyFeatureGrouping objPropertyFeatureGrouping = ExtractPropertyFeatureGroupingData(item);
                        foreach (var feature in item["features"])
                        {
                            if (item != null && feature.HasValues)
                            {
                                PropertyFeature objPropertyFeature = ExtractPropertyFeatureData(feature);
                                objPropertyFeature.PropertyFeatureGrouping = objPropertyFeatureGrouping;
                                lstPropertyFeature.Add(objPropertyFeature);
                            }
                        }
                        lstPropertyFeatureGrouping.Add(objPropertyFeatureGrouping);
                    }
                }

                using var scope = serviceProvider.CreateScope();
                await UpsertPropertyFeatureGroupingData(scope, lstPropertyFeatureGrouping);
                await UpsertlstPropertyFeatureData(scope, lstPropertyFeature);
                await UpsertPropertyFeatureProperty(scope, lstPropertyFeature, propertyId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private async Task UpsertPropertyFeatureProperty(IServiceScope scope, List<PropertyFeature> lstPropertyFeature, int propertyId)
        {
            var propertyFeaturePropertyRepo = scope.ServiceProvider.GetRequiredService<IPropertyFeaturePropertyRepository>();
            await propertyFeaturePropertyRepo.UpsertPropertyFeatureProperty(lstPropertyFeature.Select(x => x)
                        .Where(x => x != null && x.Data == "true").ToList()
                        .GroupBy(elem => elem.Name)
                        .Select(group => group.First()).ToList(), propertyId);
        }

        public PropertyFeatureGrouping ExtractPropertyFeatureGroupingData(JToken item)
        {
            JsonProcessor<PropertyFeatureGrouping> objJsonProcessor = new();
            PropertyFeatureGrouping objPropertyFeature = (PropertyFeatureGrouping)objJsonProcessor.ExtractData<PropertyFeatureGrouping>(item);
            objPropertyFeature.Id = 0;
            objPropertyFeature.CreatedBy = ERConstants.PROPERTY_FEATURE_PROCESSOR;
            objPropertyFeature.ModifieldBy = ERConstants.PROPERTY_FEATURE_PROCESSOR;
            return objPropertyFeature;
        }
        public PropertyFeature ExtractPropertyFeatureData(JToken item)
        {
            JsonProcessor <PropertyFeature> objJsonProcessor = new();
            PropertyFeature objPropertyFeature = (PropertyFeature)objJsonProcessor.ExtractData<PropertyFeature>(item);
            objPropertyFeature.Id = 0;
            objPropertyFeature.PropertyFeatureGroupingId = 0;
            objPropertyFeature.CreatedBy = ERConstants.PROPERTY_FEATURE_PROCESSOR;
            objPropertyFeature.ModifieldBy = ERConstants.PROPERTY_FEATURE_PROCESSOR;
            return objPropertyFeature;
        }
        public async Task UpsertPropertyFeatureGroupingData(IServiceScope scope, List<PropertyFeatureGrouping> lstPropertyFeatureGrouping)
        {
            var propertyFeatureGroupingRepo = scope.ServiceProvider.GetRequiredService<IPropertyFeatureGroupingRepository>();
            await propertyFeatureGroupingRepo.UpsertPropertyFeatureGroupings(lstPropertyFeatureGrouping.Select(x => x)
                        .Where(x => x != null ).ToList()
                        .GroupBy(elem => elem.GroupName)
                        .Select(group => group.First()).ToList());
        }
        public async Task UpsertlstPropertyFeatureData(IServiceScope scope, List<PropertyFeature> lstPropertyFeature)
        {
            var propertyFeatureRepo = scope.ServiceProvider.GetRequiredService<IPropertyFeatureRepository>();
            await propertyFeatureRepo.UpsertPropertyFeatures(lstPropertyFeature.Select(x => x)
                        .Where(x => x != null).ToList()
                        .GroupBy(elem => elem.Name)
                        .Select(group => group.First()).ToList());
        }
    }
}
