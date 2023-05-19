import React from 'react';
import { CustomTask } from '../../../types/interfaces/interfaces';

type EmployeeAssignedTasksProps = {
    tasks: CustomTask[];
    tasksForText: string;
}
const EmployeeAssignedTasks = (props: EmployeeAssignedTasksProps) => {
    const assignedTasks = props.tasks;
    
    return (
        <div className="assigned-tasks-container">
            <h2>{props.tasksForText}</h2>
            {
                assignedTasks && assignedTasks.length > 0 && assignedTasks.map((task:CustomTask) => {
                    return (
                        <div className="assigned-tasks-item">
                            <span>{task.customTaskText}</span>
                            <span>{task.customTaskDueDate.toISOString()}</span>
                        </div>
                    );
                })
            }
        </div>
    )
    

}

export default EmployeeAssignedTasks;