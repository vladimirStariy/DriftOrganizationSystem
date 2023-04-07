using DriftOrganizationSystem.Data;
using DriftOrganizationSystem.Data.Repository;
using DriftOrganizationSystem.Domain.Entity;
using DriftOrganizationSystem.Domain.Enum;
using DriftOrganizationSystem.Domain.Response;
using DriftOrganizationSystem.Domain.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriftOrganizationSystem.Service.Services
{
    public class PilotService
    {
        PilotRepository _pilotRepository = new PilotRepository();
        public void Create(PilotViewModel model)
        {
            //try
            //{
                var pilot = new Pilot()
                {
                    Surname = model.Surname,
                    Name = model.Name,
                    Fathername = model.Fathername,
                    Age = model.Age
                };

                _pilotRepository.AddPilot(pilot);

                //return new BaseResponse<Pilot>()
                //{
                //    Result = pilot,
                //    Description = "Пилот добавлен",
                //    StatusCode = StatusCode.OK
                //};
            //}
            //catch (Exception ex)
            //{
            //    return new BaseResponse<Pilot>()
            //    {
            //        Description = $"Ошибка: {ex.Message}",
            //        StatusCode = StatusCode.Error
            //    };
            //}
        }
        public List<Pilot> GetPilots()
        {
            //try
            //{
                var pilots = _pilotRepository.GetPilots();
                //if (!pilots.Any())
                //{
                //    return new BaseResponse<List<Pilot>>()
                //    {
                //        Description = "Пилотов нет",
                //        StatusCode = StatusCode.OK
                //    };
                //}
                return pilots;
            //    return new BaseResponse<List<Pilot>>()
            //    {
            //        Result = pilots,
            //        StatusCode = StatusCode.OK
            //    };
            //}
            //catch (Exception ex)
            //{
            //    return new BaseResponse<List<Pilot>>()
            //    {
            //        Description = $"[GetPilots] : {ex.Message}",
            //        StatusCode = StatusCode.Error
            //    };
            //}
        }
    }
}
