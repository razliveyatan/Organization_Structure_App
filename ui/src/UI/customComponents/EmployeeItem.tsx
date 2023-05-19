import React from 'react';
import { Employee } from '../../types/interfaces/interfaces';
import Button from '../buttons/Button';
type EmployeeItemProps = {
    employee: Employee,
    onViewEmployee: (employee: Employee) => void,
}

const EmployeeItem = (props: EmployeeItemProps) => {
    const viewEmployee = () => {
        props.onViewEmployee(props.employee);
    }

  return (
      <div>
          <span>{props.employee.firstName}</span>
          <span>{props.employee.lastName}</span>
          <span>{props.employee.position}</span>
          <Button label="View" onClick={viewEmployee}/> 
      </div>
  );
}

export default EmployeeItem;