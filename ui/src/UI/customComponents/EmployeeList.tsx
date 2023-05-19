import React, { useEffect, useState, useCallback } from 'react';
import { getAllEmployees} from '../../services/data-service';
import EmployeeAutocomplete from '../helpers/EmployeesAutocomplete'; 
import { Employee } from '../../types/interfaces/interfaces';
import EmployeeItem from './EmployeeItem';
import Modal from '../modals/Modal';
import EmployeeDetails from './employee-details-page/EmployeeDetailsGeneral';
import { toast } from 'react-toastify';

const EmployeeList = () => {
    const [employees, setEmployees]: any = useState([]);
    const [employeeResults, setEmployeeResults]: any = useState([]);
    const [isOpen, setIsOpen] = useState(false);
    const [viewEmployee, setViewEmployee]: any = useState(null);

    const fetchData = useCallback(async () => {
        try {
            const employeesReponse = await getAllEmployees();
            if (employeesReponse && employeesReponse.data) {
                setEmployees(employeesReponse.data.relatedData);                
            }
        } catch (error: any) {
            toast('Error getting employees' + error.message, { type: 'error' })
        }
    }, []);

     useEffect(() => {         
        fetchData(); 
    }, []);

    const handleEmployeeSearchClick = (employee: Employee) => {
        if (employee) {
            const results = employees.filter((emp: Employee) => emp.employeeId === employee.employeeId);
            if (results && results.length > 0) {
                setEmployeeResults(results);
            }
        }
    }

    const handleCloseModal = () => {
        setIsOpen(false);
    }

    const handleEmployeeClick = (employee: Employee) => {
        if (employee) {
            setIsOpen(true);
            setViewEmployee(employee);
        }
    }

    return (
        <div className="employee-list">
            <h1 className="page-title">Employee List</h1>
            <div className="search-bar-container">
                <EmployeeAutocomplete employees={employees} onEmployeeAutocompleteClick={handleEmployeeClick} />
            </div>
            {/*<div className={`${employeeResults.length > 0 ? 'employee-results' : 'hidden'}`}>*/}
            {/*    {*/}
            {/*        employeeResults.map((employee: Employee) => {*/}
            {/*            return (<EmployeeItem onViewEmployee={handleEmployeeClick} key={employee.employeeId} employee={employee} />)*/}
            {/*        })*/}
            {/*    }*/}
            {/*</div>*/}
            {
                isOpen && viewEmployee && <Modal isOpen={isOpen} onClose={handleCloseModal}>
                    <EmployeeDetails employee={viewEmployee} key={viewEmployee.employeeId} />
                </Modal>
            }
            
        </div>
    );
};

export default EmployeeList;