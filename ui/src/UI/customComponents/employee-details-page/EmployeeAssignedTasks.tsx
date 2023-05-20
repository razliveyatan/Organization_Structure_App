import React from 'react';
import { CustomTask } from '../../../types/interfaces/interfaces';

type EmployeeAssignedTasksProps = {
    tasks: CustomTask[];
    tasksForText: string;
}
const EmployeeAssignedTasks = (props: EmployeeAssignedTasksProps) => {
    const assignedTasks = props.tasks;
    
    return (
        <>
            <h2>{props.tasksForText}</h2>
            <div className="assigned-tasks-headers">
                <div className="taskName">Task</div>
                <div className="taskDate">Date</div>
            </div>
            <div className="assigned-tasks-container">                
                {
                    assignedTasks && assignedTasks.length > 0 && assignedTasks.map((task: CustomTask) => {
                        return (
                            <div className="assigned-tasks-item" key={task.customTaskId}>
                                <div className="taskName">{task.customTaskText}</div>
                                <div className="taskDate">{new Date(task.customTaskAssignDate).toDateString()}</div>
                            </div>
                        );
                    })
                }
                {
                    !assignedTasks || assignedTasks.length === 0 ? <div className="assigned-tasks-item">No tasks assigned</div> : null
                }
            </div>
        </>
        
    )
    

}

export default EmployeeAssignedTasks;