﻿using System.Collections.Generic;
using WeatherApi.Core.Entities;
using WeatherApi.Core.Abstractions.Services;
using WeatherApi.Core.Abstractions;
using System.Linq;

namespace WeatherApi.Services
{
    public class TemperatureService : ITemperatureService
    {
        private IUnitOfWork unitOfWork;
       
        public TemperatureService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public void Delete()
        {
            unitOfWork.TemperatureRepository.RemoveAll();
            unitOfWork.Save();
        }

        public List<Temperature> GetAll()
        {
            var result = unitOfWork.TemperatureRepository.List().ToList();
            unitOfWork.Save();

            return result;
        }

        public void Insert(List<Temperature> entities)
        {
            unitOfWork.TemperatureRepository.AddRange(entities);
            unitOfWork.Save();
        }
    }
}
