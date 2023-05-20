import React, { useState } from 'react';
import { Employee, CustomTask } from '../../../types/interfaces/interfaces';
import Button from '../../buttons/Button';
import Modal from '../../modals/Modal';
import AssignTaskForm from './forms/AssignTaskForm';


type managerSubordinateProps = {
    subordinates: Employee[];
    onSubordinateAssignTaskClick: (task: CustomTask) => void;
    title: string;
}
const ManagerSubordinates = (props: managerSubordinateProps) => {
    const subordinates = props.subordinates;
    const [sub, setSubEmployee] = useState<Employee>({} as Employee);
    const [isOpen, setIsOpen] = useState(false);

    const handleOnSubmitSucces = (task: CustomTask) => {
        if (task) {
            setIsOpen(false);
            props.onSubordinateAssignTaskClick(task);
        }
    }

    const onSubordinateAssignTaskClick = (employee: Employee) => {
        if (employee) {
            setIsOpen(true);
            setSubEmployee(employee);
        }
    }

    return (
        <>
          <h2>{props.title}</h2>
            <div className="section-headers">
                <div className="sub-fullName">Full Name</div>
                <div className="sub-position">Position</div>
            </div>
  
            <div className="employee-section-container">           
            {
                subordinates && subordinates.map((sub: Employee) => {
                    return (
                        <div className="section-item" key={sub.employeeId}>
                            <span>{sub.firstName}, {sub.lastName}</span>
                            <span>{sub.position}</span>
                            <Button label="Assign Task" onClick={() => onSubordinateAssignTaskClick(sub)} customClass={null } />
                        </div>
                    );
                })
            }
            <Modal isOpen={isOpen} onClose={() => { setIsOpen(false) }} >
                <AssignTaskForm employee={sub} handleOnSuccess={handleOnSubmitSucces} />
            </Modal>
            </div>
        </>
    )
}

export default ManagerSubordinates;