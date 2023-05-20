import { get , post} from "./domain-services";
import { appConstants } from "../types/constants/constants";
import { Employee, Report, CustomTask, IResponse } from "../types/interfaces/interfaces";

export const getEmployeeDetails = async (employeeId: number) => {
    try {        
        return get(appConstants.getEmployeeDetailsApi, { employeeId });
    } catch (error) {
        console.error(error);
    }    
}

export const getCustomTasksToEmployee = async (employeeId: number) => {
    try {
        return get(appConstants.getCustomTasksToEmployeeApi, { employeeId });
    } catch (error) {
        console.error(error);
    }
}

export const getAllEmployees = async ():Promise<any> => {
    try {
        return get(appConstants.getAllEmployeesApi);
    } catch (error) {
        console.error(error);
    }
}


export const getReportsFromSubordinates = async (managerId: number) => {
    try {
        return get(appConstants.getReportsFromSubordinatesApi, { managerId });
    } catch (error) {
        console.error(error);
    }
}

export const getManagerSubordinates = async (managerId: number) => {
    try {
        return get(appConstants.getReportsFromSubordinatesApi, { managerId });
    } catch (error) {
        console.error(error);
    }
}

export const assignTasksToEmployee = async (task: CustomTask) => {
    try {
        return post(appConstants.assignTasksToEmployeeApi, {
            customTaskId: task.customTaskId,
            managerId: task.managerId,
            employeeId: task.employeeId,
            customTaskText: task.customTaskText,
            customTaskDueDate: task.customTaskDueDate,
            customTaskAssignDate: task.customTaskAssignDate
        });
    }
    catch (error) {
        console.error(error);
    }
}

export const submitReport = async (report: Report) => {    
    try {
        return post(appConstants.submitReportApi, {
            reportId: report.reportId,
            employeeId: report.employeeId,
            reportText: report.reportText,
            reportDate: report.reportDate,
            managerId: report.managerId,
            reportStatus: report.reportStatus
        })            
    } catch (error) {
        console.error(error);
    }
}