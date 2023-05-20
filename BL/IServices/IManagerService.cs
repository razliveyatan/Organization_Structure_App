﻿using DAL.Types;

namespace BL.IServices
{
    public interface IManagerService
    {
        Task<ICollection<Employee>> GetReportsFromSubordinates(int managerId);
        Task<ICollection<Employee>> GetManagerSubordinates(int managerId);
    }
}
