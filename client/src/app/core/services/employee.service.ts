import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee, EmployeeId, EmployeeListItem, EmployeeListResponse, UpdateEmployee, UpdateEmployeeResponse, ViewEmployeeResponse } from '../models/employee.model';
import { map, Observable } from 'rxjs';
import { AddEmployeeResponse } from '../responses/employee.responses';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = 'https://localhost:7097/api/Employee';

  constructor(private http: HttpClient) { }

  addEmployee(employeeModel: Employee): Observable<AddEmployeeResponse> {
    return this.http.post<AddEmployeeResponse>(`${this.apiUrl}/add-employee`, employeeModel);
  }

  viewEmployeesList(): Observable<EmployeeListItem[]> {
    return this.http
      .get<EmployeeListResponse>(`${this.apiUrl}/get-employees`)
      .pipe(
        map(response => response.employees ?? [])
      );
  }

  viewEmployeeById(employeeId: number): Observable<Employee> {
    return this.http
      .get<ViewEmployeeResponse>(`${this.apiUrl}/view-employee`, {
        params: { employeeId: employeeId.toString() }
      })
      .pipe(
        map(response => response.employee)
      );
  }

  updateEmployee(employee: UpdateEmployee): Observable<UpdateEmployeeResponse> {
    return this.http.put<UpdateEmployeeResponse>(`${this.apiUrl}/update-employee`, employee);
  }

  removeEmployee(employeeId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/delete-employee`, {
      params: { employeeId: employeeId.toString() }
    });
  }
}
