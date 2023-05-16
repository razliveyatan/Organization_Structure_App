using BL.IServices;
using DAL.Repositories;
using DAL.Types;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CustomTaskService : ITaskService
    {
        private readonly LoggerService _loggerService;
        private readonly CustomTaskRepository _customTaskRepository;

        public CustomTaskService( CustomTaskRepository customTaskRepository, LoggerService loggerService)
        {
            _customTaskRepository = customTaskRepository;
            _loggerService = loggerService;   
        }

        public void AssignTaskToEmployee(CustomTask customTask)
        {
            try
			{                
                _customTaskRepository.AddCustomTask(customTask);
                _customTaskRepository.SaveChange();
            }
			catch (Exception ex)
			{
                _loggerService.LogError(ex.Message, nameof(CustomTaskService), nameof(AssignTaskToEmployee));
            }
        }
    }
}
