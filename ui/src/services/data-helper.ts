import { reportStatusEnum } from "../types/enums/enums"
import { Report } from "../types/interfaces/interfaces"

export const normalizeReportObject = (objectToNormalize: any) => {
    return {
        reportText: objectToNormalize.reportText !== '' ? objectToNormalize.reportText : 'No report text',
        reportDate: objectToNormalize.reportDate ? objectToNormalize.reportDate : new Date(),
        reportStatus: objectToNormalize.reportStatus ? objectToNormalize.reportStatus : reportStatusEnum.New,
        employeeId: objectToNormalize.employeeId ? objectToNormalize.employeeId : 0,
        managerId: objectToNormalize.managerId ? objectToNormalize.managerId : 0,
    } as Report
}