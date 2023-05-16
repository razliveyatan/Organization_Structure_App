using DAL.Types;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CustomTaskRepository
    {
        private readonly Org_Structure_DbContext dbContext;
        public CustomTaskRepository(Org_Structure_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddCustomTask(CustomTask customTask)
        {
            dbContext.CustomTasks.Add(customTask);
        }

        public void DeleteCustomTask(CustomTask customTask)
        {            
            dbContext.CustomTasks.Remove(customTask);
        }

        public async Task<CustomTask> GetCustomTaskById(int id)
        {           
                return await dbContext?.CustomTasks?.FirstOrDefaultAsync(x => x.CustomTaskId == id);                     
        }

        public async Task<CustomTask> EditCustomTask(CustomTask customTask)
        {
            var customTaskToEdit = dbContext.CustomTasks.FirstOrDefault(x => x.CustomTaskId == customTask.CustomTaskId);
            customTaskToEdit.CustomTaskText = customTask.CustomTaskText;
            customTaskToEdit.CustomTaskDueDate = customTask.CustomTaskDueDate;
            customTaskToEdit.CustomTaskAssignDate = customTask.CustomTaskAssignDate;            
            return customTaskToEdit;
        }
        public void SaveChange()
        {
            dbContext.SaveChanges();
        }
    }
}
