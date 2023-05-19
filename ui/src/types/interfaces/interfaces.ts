import { reportStatusEnum }  from '../enums/enums';

export interface CustomTask {
    customTaskId: number,
    managerId: number,
    employeeId: number,
    customTaskText: string,
    customTaskDueDate: Date,
    customTaskAssignDate: Date
}

export interface Employee {    
    employeeId: number,
    firstName: string,
    lastName: string,
    address: string,
    phone: string,
    pictureUrl: string,
    position: string,
    managerId: number,
    manager: Employee | null,
    employees: Employee[] | [],
    customTasks: CustomTask[] | [],
    reports: Report[] | []
}

export interface Report {
    reportId: number,
    employeeId: number,
    reportText: string,
    reportDate: Date,
    managerId: number,
    employee: Employee,
    reportStatus: reportStatusEnum
}

export interface IResponse {
    data: object[],
    statusCode: number,    
}




