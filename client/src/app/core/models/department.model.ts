
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