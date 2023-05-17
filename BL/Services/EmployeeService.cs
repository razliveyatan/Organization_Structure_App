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
    public class EmployeeService : IEmployeeService, IReportService
    {
        //private readonly LoggerService _loggerService;
        private readonly EmployeeRepository _employeeRepository;
        private readonly ReportRepository _reportRepository;

        //public EmployeeService(EmployeeRepository employeeRepository, ReportRepository reportRepository, LoggerService loggerService)
        //{
        //    _employeeRepository = employeeRepository;
        //    _reportRepository = reportRepository;
        //    _loggerService = loggerService;
        //}

        public EmployeeService(EmployeeRepository employeeRepository, ReportRepository reportRepository)
        {
            _employeeRepository = employeeRepository;
            _reportRepository = reportRepository;
        }

        public async Task<ICollection<Employee>> GetAllEmployees()
        {
            try
            {
                return await _employeeRepository.GetAllEmployees();
            }
            catch (Exception ex)
            {
                //_loggerService.LogError(ex.Message, nameof(EmployeeService), nameof(GetAllEmployees));
                throw new Exception(ex.Message);
            }
        }


        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            try
            {
                return await _employeeRepository.GetEmployeeDetails(employeeId);
            }
            catch (Exception ex)
            {
                //_loggerService.LogError(ex.Message, nameof(EmployeeService), nameof(GetEmployeeDetails));
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<CustomTask>> GetCustomTasksToEmployee(int employeeId)
        {
            try
            {
                return await _employeeRepository.GetCustomTasksByEmployee(employeeId);
            }
            catch (Exception ex)
            {
                //_loggerService.LogError(ex.Message, nameof(EmployeeService), nameof(GetCustomTasksToEmployee));
                throw new Exception(ex.Message);
            }            
        }       

        public void SubmitReport(Report report)
        {
            try
            {
                _reportRepository.AddReport(report);
                _reportRepository.SaveChange();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);               
            }
        }
    }
}
