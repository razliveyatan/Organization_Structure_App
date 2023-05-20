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
            <div className="section-headers">
                <div className="reportText">Title</div>
                <div className="reportDate">Date</div>
                <div className="reportStatus">Status</div>
            </div>
            <div className="employee-section-container">
                {
                    filedReports && filedReports.map((report: Report) => {
                        return (
                            <div className="section-item" key={report.reportId}>
                                <span>{report.reportText}</span>
                                <span>{new Date(report.reportDate).toDateString()}</span>
                                <span>{reportStatusEnum[report.reportStatus]}</span>
                            </div>
                        );
                    })
                }
                {
                    !filedReports || filedReports.length === 0 ? <div className="report-file-item">No Filed Reports</div> : null
                }
            </div>
        </>
        
    )
}

export default EmployeeReportsView;