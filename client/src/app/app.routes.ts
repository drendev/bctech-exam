import { Routes } from '@angular/router';
import { EditEmployeeComponent } from './features/employee/edit-employee/edit-employee.component';
import { AddEmployeeComponent } from './features/employee/add-employee/add-employee.component';
import { ViewEmployeesComponent } from './features/employee/view-employees/view-employees.component';
import { GetEmployeeComponent } from './features/employee/get-employee/get-employee.component';

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
    }
];
