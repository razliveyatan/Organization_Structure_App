import React, { useEffect, useState } from 'react';
import { getAllEmployees } from '../../services/data-service';
import EmployeeAutocomplete from '../helpers/EmployeesAutocomplete';

const EmployeeList = () => {
    const [employees, setEmployees]:any = useState([]);
    useEffect(() => {
        const fetchData = async () => {
            try {
                const employeesReponse = await getAllEmployees(); 
                if (employeesReponse && employeesReponse.data) {
                    setEmployees(employeesReponse.data);
                }
            } catch (error) {
                console.error(error);
            }
        };
        fetchData(); 
    }, []);

    return (
        <div className="employee-list">
            <h1 className="page-title">Employee List</h1>
            <div className="search-bar-container">
                <EmployeeAutocomplete employees={employees} />
            </div>
            
        </div>
    );
};

export default EmployeeList;