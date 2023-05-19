import React, { useState} from 'react';
import { Employee, Report, CustomTask } from '../../../types/interfaces/interfaces';
import EmployeeAssignedTasks from './EmployeeAssignedTasks';
import ManagerSubordinates from './ManagerSubordinates';
import EmployeeReportsView from './EmployeeReportsView';
import Button from '../../buttons/Button';
import Modal from '../../modals/Modal';
import ReportForm from '../../customComponents/employee-details-page/forms/ReportForm';



type EmployeeDetailsProps = {
    employee: Employee
}
const EmployeeDetails = (props: EmployeeDetailsProps) => {
    const mySubordinatesTasks = props.employee.employees ? props.employee.employees.map(emp => emp.customTasks?.filter(task => task.managerId === props.employee.employeeId)).flat() : [];
    const myFiledReports = props.employee.reports.filter(report => report.employeeId === props.employee.employeeId);
    const [updateEmployee, setUpdateEmployee]:any = useState(props.employee);
    const [isOpen, setIsOpen] = useState(false);


    //const fetchData = useCallback(async () => {
    //    try {
    //        const managerSubordinatesReponse = await ();
    //        if (employeesReponse && employeesReponse.data) {
    //            setEmployees(employeesReponse.data.relatedData);
    //            console.log('getEmployees');
    //        }
    //    } catch (error: any) {
    //        toast('Error getting employees' + error.message, { type: 'error' })
    //    }
    //}, []);

    //useEffect(() => {
    //    fetchData();
    //}, []);

    const handleOnSubmitSucces = (report:Report) => {
        if (report) {
            setUpdateEmployee({ ...updateEmployee, reports: [...updateEmployee.reports, report] });
            setIsOpen(false);
        }
    }

    const handleOnAssignTaskSuccess = (task: CustomTask) => {
        if (task) {
            setUpdateEmployee({ ...updateEmployee, customTasks: [...updateEmployee.customTasks, task] });
            setIsOpen(false);
        }
    }

    const openReportForm = () => {
        return (
            //<Modal isOpen={true} onClose={() => { setIsOpen(false) }} >
            //    <ReportForm employee={updateEmployee} handleOnSuccess={handleOnSubmitSucces} />
            //</Modal>
            setIsOpen(true)

        )
    }
    return (
        <div className="general-employee-details-container">
            <div className="employee-details-top">
                <div className="employee-details-top-left">
                    <img src={updateEmployee.pictureUrl} alt={updateEmployee.firstName + ", " + updateEmployee.lastName} />
                </div>
                <div className="employee-details-top-right">
                    <label>Name</label>
                    <span>{updateEmployee.firstName + ", " + updateEmployee.lastName}</span>
                    <label>Position</label>
                    <span>{updateEmployee.position}</span>
                </div>
                {
                    updateEmployee.managerId ? <div className="employee-details-bottom-right">
                        <label>Manager</label>
                        <span>{updateEmployee.manager?.firstName + ", " + updateEmployee.manager?.lastName}</span>
                        <Button label="Report" onClick={openReportForm} />
                    </div> : null
                }
            </div>
            <div className="employee-details-bottom">
                {
                    updateEmployee && updateEmployee.customTasks.length > 0 ? <EmployeeAssignedTasks tasksForText='My Tasks' tasks={updateEmployee.customTasks} /> : null
                }
                {/*{*/}
                {/*    updateEmployee && updateEmployee.employees.length > 0 ? <ManagerSubordinates title={'My Subordinates'} onSubordinateAssignTaskClick={handleOnAssignTaskSuccess} subordinates={updateEmployee.employees} /> : null*/}
                {/*}*/}
                {/*{*/}
                {/*    updateEmployee && updateEmployee.employees.length > 0 && mySubordinatesTasks && mySubordinatesTasks.length > 0 ? <EmployeeAssignedTasks tasksForText='My Subordinates Tasks' tasks={mySubordinatesTasks} /> : null*/}
                {/*}*/}
                {
                    myFiledReports.length > 0 ? <EmployeeReportsView reports={myFiledReports }  reportsForText='My Reports'/> : null
                }

            </div>
            {
                isOpen && updateEmployee && <Modal isOpen={isOpen} onClose={() => { setIsOpen(false) }} >
                    <ReportForm employee={updateEmployee} handleOnSuccess={handleOnSubmitSucces} />
                </Modal>
            }
            
        </div>
    );
}

export default EmployeeDetails;