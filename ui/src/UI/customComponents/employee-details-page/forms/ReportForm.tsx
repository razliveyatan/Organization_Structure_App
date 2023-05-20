import React, { useState } from 'react';
import { Employee, Report } from './../../../../types/interfaces/interfaces'
import { reportStatusEnum } from './../../../../types/enums/enums';
import Button from '../../../buttons/Button';
import { submitReport } from '../../../../services/data-service';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

type ReportFormProps = {
    employee: Employee,
    handleOnSuccess: (report:Report) => void;
}
const ReportForm = (props: ReportFormProps) => {
    const [inputValue, setInputValue] = useState('');
    const [selectValue, setSelectValue] = useState(0);

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(event.target.value);
    };

    const handleSelectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        const selectedValue: string = (event.target.value);
        if (selectedValue !== '') {
            const enumValue = parseInt(selectedValue);
            setSelectValue(enumValue);
        }        
    }

    const handleSubmitReport = async () => {
        if (inputValue !== '' && selectValue > 0) {
            const report = {
                reportId:0,
                reportText: inputValue,
                reportStatus: selectValue,
                employeeId: props.employee.employeeId,
                managerId: props.employee.managerId,
                reportDate: new Date(),
            } as Report;
            const submitReportResponse = await submitReport(report);
            if (submitReportResponse && submitReportResponse.statusCode === 200) {
                toast('Report Submit Success');
                setInputValue('');
                setSelectValue(0);
                props.handleOnSuccess(report);
            }
            else {
                toast('Report Submit Failed');
            }
        }
    }
        return (
            <div className="report-form-container">
                <div className="report-form-header">
                    <h1>{props.employee.firstName}, {props.employee.lastName} Report</h1>
                </div>
                <div className="report-form-body">
                    <input type='text' placeholder="Report Text" onChange={handleInputChange} value={inputValue} />
                    <select name="reportStatus" id="reportStatus" onChange={handleSelectChange}>
                        {(Object.keys(reportStatusEnum).filter((v) => isNaN(Number(v)),) as (keyof typeof reportStatusEnum)[]).map((key:any,index:number) => (
                            <option key={reportStatusEnum[key]} value={reportStatusEnum[key]}>{key}</option>
                        ))}
                    </select>
                </div>
                <Button label="Save" onClick={handleSubmitReport} />
                <ToastContainer />
            </div>
        );
    }

    export default ReportForm;