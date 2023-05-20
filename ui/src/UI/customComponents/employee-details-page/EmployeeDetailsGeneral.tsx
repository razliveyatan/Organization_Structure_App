import React, { useState, useCallback , useEffect} from 'react';
import { Employee, Report, CustomTask } from '../../../types/interfaces/interfaces';
import EmployeeAssignedTasks from './EmployeeAssignedTasks';
import ManagerSubordinates from './ManagerSubordinates';
import EmployeeReportsView from './EmployeeReportsView';
import Button from '../../buttons/Button';
import Modal from '../../modals/Modal';
import ReportForm from '../../customComponents/employee-details-page/forms/ReportForm';
import { getManagerSubordinates } from '../../../services/data-service';
import { toast } from 'react-toastify';




type EmployeeDetailsProps = {
    employee: Employee
}
const EmployeeDetails = (props: EmployeeDetailsProps) => {
    const [subordinates, setSubordinates]: any = useState([]);
    const myFiledReports = props.employee.reports.filter(report => report.employeeId === props.employee.employeeId);
    const [updateEmployee, setUpdateEmployee]: any = useState(props.employee);
    const [loading, setLoading] = useState(false);
    const [isOpen, setIsOpen] = useState(false);
    const demoImageUrl = 'https://as2.ftcdn.net/v2/jpg/00/65/77/27/1000_F_65772719_A1UV5kLi5nCEWI0BNLLiFaBPEkUbv5Fv.jpg';


    const fetchData = useCallback(async () => {

        if (props.employee.isManager) {
            try {
                setLoading(true);
                const subordinatesReponse = await getManagerSubordinates(props.employee.employeeId);
                if (subordinatesReponse && subordinatesReponse.data) {
                    setSubordinates(subordinatesReponse.data.relatedData);
                    setLoading(false);
                }
            } catch (error: any) {
                toast('Error getting employees' + error.message, { type: 'error' })
            }
        }
    }, []);

    useEffect(() => {
        fetchData();
    }, []);

    const handleOnSubmitSucces = (report: Report) => {
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
            <h2>Employee Card</h2>
            <div className="employee-details-top">
                <div className="employee-details-top-left">
                    <img src={updateEmployee.pictureUrl ? updateEmployee.pictureUrl : demoImageUrl} alt={updateEmployee.firstName + ", " + updateEmployee.lastName} />
                </div>
                <div className="employee-details-top-right">
                    <div>
                        <label>Name:</label>
                        <span>{updateEmployee.firstName + ", " + updateEmployee.lastName}</span>
                    </div>
                    <div>
                        <label>Position:</label>
                        <span>{updateEmployee.position}</span>
                    </div>
                </div>
                {
                    updateEmployee.managerId && updateEmployee.managerFullName ? <div className="employee-details-bottom-right">
                        <label>Manager:</label>
                        <span>{updateEmployee.managerFullName}</span>
                        <Button label="Report" onClick={openReportForm} />
                    </div> : null
                }
            </div>
            <div className="employee-details-bottom">
                {
                    updateEmployee && updateEmployee.customTasks.length > 0 ? <EmployeeAssignedTasks tasksForText='My Tasks' tasks={updateEmployee.customTasks} /> : null
                }
                {
                    !loading && updateEmployee && subordinates.length > 0 ? <ManagerSubordinates title={'My Subordinates'} onSubordinateAssignTaskClick={handleOnAssignTaskSuccess} subordinates={subordinates} /> : null
                }
                {/*{*/}
                {/*    updateEmployee && updateEmployee.employees.length > 0 && mySubordinatesTasks && mySubordinatesTasks.length > 0 ? <EmployeeAssignedTasks tasksForText='My Subordinates Tasks' tasks={mySubordinatesTasks} /> : null*/}
                {/*}*/}
                {
                    myFiledReports.length > 0 ? <EmployeeReportsView reports={myFiledReports} reportsForText='My Reports' /> : null
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