import { PersonalInfo } from "./personal-info.model";

export interface Employee {
    jobTitle: string;
    salary: number | null;
    isActive: boolean;
    departmentId: number | null;
    personalInfo: PersonalInfo;
}
export interface EmployeeListResponse {
    success: boolean;
    message: string;
    employees: EmployeeListItem[];
}

export interface EmployeeListItem {
    employeeId: number;
    firstName: string;
    lastName: string;
    departmentName: string;
    jobTitle: string;
    isActive: boolean;
}

export interface EmployeeId {
    employeeId: number;
}

export interface ViewEmployeeResponse {
    success: boolean;
    message: string;
    employee: Employee;
}

export interface UpdateEmployee {
    employeeId: number;
    jobTitle: string;
    salary: number | null;
    isActive: boolean;
    departmentId: number | null;
    personalInfo: PersonalInfo;
}

export interface UpdateEmployeeResponse {
    success: boolean;
    message: string;
    employee: UpdateEmployee;
}