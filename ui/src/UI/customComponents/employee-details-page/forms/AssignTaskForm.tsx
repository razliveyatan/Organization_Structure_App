import React, { useState } from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { assignTasksToEmployee } from '../../../../services/data-service';
import { CustomTask, Employee } from '../../../../types/interfaces/interfaces';
import Button from '../../../buttons/Button';

type AssignTaskFormProps = {
    employee: Employee,
    handleOnSuccess: (task: CustomTask) => void;
}
const AssignTaskForm = (props: AssignTaskFormProps) => {
    const [inputValue, setInputValue] = useState('');
    const [dueDate, setTaskDueDate] = useState('DD/MM/YYYY');

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(event.target.value);
    };

    const handleDueDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const dueDate: string = (event.target.value);
        if (dueDate !== '') {
            setTaskDueDate(dueDate);
        }
    }

    const handleAssignTask = async () => {
        if (inputValue !== '' && dueDate !== '') {
            const task = {
                customTaskText: inputValue,
                customTaskAssignDate: new Date(),
                customTaskDueDate: new Date(dueDate),
                managerId: props.employee.managerId,
                employeeId: props.employee.employeeId,                
            } as CustomTask;

            const submitAssignTaskResponse = await assignTasksToEmployee(task);
            if (submitAssignTaskResponse && submitAssignTaskResponse.statusCode === 200) {                
                toast('Task Assigned Successfully!');
                setInputValue('');
                setTaskDueDate('DD/MM/YYYY');
                props.handleOnSuccess(task);
            }
            else {
                toast('Assign Task Failed');
            }
        }
    }
    return (
        <div className="assign-task-form-container">
            <div className="assign-task-form-header">
                <h1>Task For {props.employee.firstName}, {props.employee.lastName}</h1>
            </div>
            <div className="assign-task-form-body">
                <input type='text' placeholder="Task Text" onChange={handleInputChange} value={inputValue} />
                <input type='text' placeholder="DD/MM/YYYY" onChange={handleDueDateChange} value={dueDate} />
            </div>
            <Button label="Save" onClick={handleAssignTask} />
            <ToastContainer />
        </div>
    );
}

export default AssignTaskForm;