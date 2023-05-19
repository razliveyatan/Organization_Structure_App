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
    public class ManagerService : IManagerService, IEmployeeService, ITaskService
    {
        //private readonly LoggerService _loggerService;
        private readonly EmployeeRepository _employeeRepository;
        private readonly CustomTaskRepository _taskRepository;

        //public ManagerService(EmployeeRepository employeeRepository, CustomTaskRepository taskRepository, LoggerService loggerService)
        //{
        //    _employeeRepository = employeeRepository;
        //    _taskRepository = taskRepository;
        //    _loggerService = loggerService;
        //}

        public ManagerService(EmployeeRepository employeeRepository, CustomTaskRepository taskRepository)
        {
            _employeeRepository = employeeRepository;
            _taskRepository = taskRepository;            
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

        public async Task<Employee> GetCustomTasksToEmployee(int employeeId)
        {
            try
            {
                return await _employeeRepository.GetCustomTasksByEmployee(employeeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //_loggerService.LogError(ex.Message, "ManagerService", "GetCustomTasksToEmployee");
            }
            return null;            
        }
    }
}
