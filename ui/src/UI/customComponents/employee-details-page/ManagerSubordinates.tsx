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
    const [isOpen, setIsOpen] = useState(false);

    const handleOnSubmitSucces = (task: CustomTask) => {
        if (task) {
            setIsOpen(false);
            props.onSubordinateAssignTaskClick(task);
        }
    }

    const onSubordinateAssignTaskClick = (employee: Employee) => {
        return (
            <Modal isOpen={true} onClose={() => { setIsOpen(false) }} >
                <AssignTaskForm employee={employee} handleOnSuccess={handleOnSubmitSucces} />
            </Modal>
        )
    }

    return (
        <div className="my-subordinates-container">
            <h2>{props.title}</h2>
            {
                subordinates && subordinates.map((sub: Employee) => {
                    return (
                        <div className="subordinate-item">
                            <span>{sub.firstName}, {sub.lastName}</span>
                            <span>{sub.position}</span>
                            <Button label="Assign Task" onClick={() => onSubordinateAssignTaskClick(sub)} />
                        </div>
                    );
                })
            }
        </div>
    )
}

export default ManagerSubordinates;