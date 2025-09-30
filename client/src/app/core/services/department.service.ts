import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DepartmentList } from '../models/department.model';
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
}
