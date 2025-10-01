import { EmployeeListItem } from "./employee.model";

export interface Department {
    departmentId: number;
    name: string;
    location: string;
}

export interface DepartmentList {
    success: boolean;
    message: string;
    departments: Department[];
}

export interface AddDepartment {
    name: string;
    location: string;
}

export interface AddDepartmentResponse {
    success: boolean;
    message: string;
}

export interface DepartmentWithEmployees {
    name: string;
    location: string;
    employees: EmployeeListItem[];
}

export interface DepartmentByIdResponse {
    success: boolean;
    message: string;
    department: DepartmentWithEmployees;
}

export interface UpdateDepartment {
    departmentId: number;
    name: string;
    location: string;
}

export interface UpdateDepartmentResponse {
    success: boolean;
    message: string;
    department: UpdateDepartment;
}