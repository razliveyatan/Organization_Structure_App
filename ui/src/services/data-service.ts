import { get , post} from "./domain-services";
import { appConstants } from "../types/constants/constants";
import { Employee, Report, CustomTask } from "../types/interfaces/interfaces";

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

export const getAllEmployees = async () => {
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

export const assignTasksToEmployee = async (task: CustomTask) => {
    try {
        return post(appConstants.assignTasksToEmployeeApi, { task });
    }
    catch (error) {
        console.error(error);
    }
}

export const submitReport = async (report: Report) => {
    try {
        return post(appConstants.submitReportApi, { report })            
    } catch (error) {
        console.error(error);
    }
}