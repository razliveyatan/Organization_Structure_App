import React from 'react';
import { Employee } from '../../types/interfaces/interfaces';
import EmployeeItem from '../customComponents/EmployeeItem';
import Autocomplete from './Autocomplete';

type EmployeesAutocompleteProps = {
    employees: Employee[],
    onEmployeeAutocompleteClick: (employee: Employee) => void,
}

const EmployeeAutocomplete = (props: EmployeesAutocompleteProps) => {
    const handleSelectEmployee = (employee: Employee) => {
        if (employee) {
            props.onEmployeeAutocompleteClick(employee);
        }
    };

    const renderItem = (employee: Employee) => {
        return (
            <span>`${employee.firstName} , ${employee.lastName}`</span>
        )
    }

    return (
        <Autocomplete
            dataSource={props.employees}
            renderItem={(employee) => <span>{employee}</span>}
            onSelect={handleSelectEmployee}
            placeholder="Search for employees"
        />
    );
};

export default EmployeeAutocomplete;