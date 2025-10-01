import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddDepartment, AddDepartmentResponse, DepartmentByIdResponse, DepartmentList, UpdateDepartment, UpdateDepartmentResponse } from '../models/department.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  privateUrl = 'https://localhost:7097/api/Department';
  constructor(private http: HttpClient) { }

  viewDepartment(): Observable<DepartmentList> {
    return this.http.get<DepartmentList>(`${this.privateUrl}/all-department`);
  }

  addDepartment(department: AddDepartment): Observable<AddDepartmentResponse> {
    return this.http.post<AddDepartmentResponse>(`${this.privateUrl}/add-department`, department);
  }

  getDepartmentById(departmentId: number): Observable<DepartmentByIdResponse> {
    return this.http.get<DepartmentByIdResponse>(`${this.privateUrl}/view-department`, {
      params: { departmentId: departmentId.toString() }
    }); 
  }

  updateDepartment(department: UpdateDepartment): Observable<UpdateDepartmentResponse> {
    return this.http.put<UpdateDepartmentResponse>(`${this.privateUrl}/update-department`, department);
  }
}
