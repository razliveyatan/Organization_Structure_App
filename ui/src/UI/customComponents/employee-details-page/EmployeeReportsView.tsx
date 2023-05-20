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
        <>
            <h2>{props.reportsForText}</h2>
            <div className="reports-list-container">

                {
                    filedReports && filedReports.map((report: Report) => {
                        return (
                            <div className="report-file-item" key={report.reportId}>
                                <span>{report.reportText}</span>
                                <span>{new Date(report.reportDate).toDateString()}</span>
                                <span>{reportStatusEnum[report.reportStatus]}</span>
                            </div>
                        );
                    })
                }
            </div>
        </>
        
    )
}

export default EmployeeReportsView;