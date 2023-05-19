import React from 'react';
import { Report } from '../../../types/interfaces/interfaces';
import { reportStatusEnum } from '../../../types/enums/enums';

type EmployeeFiledReportsProps = {
    reports: Report[];
    reportsForText: string;
}

const EmployeeReportsView = (props: EmployeeFiledReportsProps) => {
    const filedReports = props.reports;

    return (
        <div className="reports-list-container">
            <h2>{props.reportsForText}</h2>
            {
                filedReports && filedReports.map((report: Report) => {
                    return (
                        <div className="report-file-item">
                            <span>{report.reportText}</span>
                            <span>{report.reportDate.toISOString()}</span>
                            <span>{reportStatusEnum[report.reportStatus]}</span>
                        </div>
                    );
                })
            }
        </div>
    )
}

export default EmployeeReportsView;