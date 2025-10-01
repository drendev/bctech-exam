import { Routes } from '@angular/router';
import { EditEmployeeComponent } from './features/employee/edit-employee/edit-employee.component';
import { AddEmployeeComponent } from './features/employee/add-employee/add-employee.component';
import { ViewEmployeesComponent } from './features/employee/view-employees/view-employees.component';
import { GetEmployeeComponent } from './features/employee/get-employee/get-employee.component';
import { AddDepartmentComponent } from './features/department/add-department/add-department.component';
import { ViewDepartmentsComponent } from './features/department/view-departments/view-departments.component';
import { GetDepartmentComponent } from './features/department/get-department/get-department.component';
import { EditDepartmentComponent } from './features/department/edit-department/edit-department.component';

export const routes: Routes = [
    {
        path: '',
        component: ViewEmployeesComponent
    },
    {
        path: 'employee/edit',
        component: EditEmployeeComponent,
    },
    {
        path: 'employee/add',
        component: AddEmployeeComponent
    },
    {
        path: 'employee/view/:id',
        component: GetEmployeeComponent
    },
    {
        path: 'employee/edit/:id',
        component: EditEmployeeComponent
    },

    // Department routes
    {
        path: 'departments',
        component: ViewDepartmentsComponent
    },

    {
        path: 'department/add',
        component: AddDepartmentComponent
    },
    {
        path: 'department/view/:id',
        component: GetDepartmentComponent
    },
    {
        path: 'department/edit/:id',
        component: EditDepartmentComponent
    }
];
