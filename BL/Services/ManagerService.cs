using BL.IServices;
using DAL.Repositories;
using DAL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ManagerService : IManagerService, ITaskService
    {
        //private readonly LoggerService _loggerService;
        private readonly EmployeeRepository _employeeRepository;
        private readonly CustomTaskRepository _taskRepository;
        private readonly ManagerRepository _managerRepository;

        //public ManagerService(EmployeeRepository employeeRepository, CustomTaskRepository taskRepository, LoggerService loggerService)
        //{
        //    _employeeRepository = employeeRepository;
        //    _taskRepository = taskRepository;
        //    _loggerService = loggerService;
        //}

        public ManagerService(EmployeeRepository employeeRepository, CustomTaskRepository taskRepository, ManagerRepository managerRepository)
        {
            _employeeRepository = employeeRepository;
            _taskRepository = taskRepository;   
            _managerRepository= managerRepository;
        }

        public void AssignTaskToEmployee(CustomTask customTask)
        {
            try
            {
                if (customTask != null)
                {
                    _taskRepository.AddCustomTask(customTask);
                    _taskRepository.SaveChange();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //_loggerService.LogError(ex.Message,"ManagerService","AssignTaskToEmployee");
            }
        }

        public async Task<ICollection<Employee>> GetManagerSubordinates(int managerId)
        {
            try
            {
                return await _managerRepository.GetManagerSubordinates(managerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }        

        public async Task<ICollection<Employee>> GetReportsFromSubordinates(int managerId)
        {
            try
            {
                return await _employeeRepository.GetReportsFromSubordinates(managerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //_loggerService.LogError(ex.Message, "ManagerService", "GetReportsFromSubordinates");
            }
            return null;            
        }    
    }
}
