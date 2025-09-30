import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../../core/services/employee.service';
import { CommonModule } from '@angular/common';
import { EmployeeListItem } from '../../../core/models/employee.model';
import { RouterModule } from '@angular/router';
import { EmployeeHeaderComponent } from "../../../shared/components/employee-header/employee-header.component";

@Component({
  selector: 'app-view-employees',
  imports: [CommonModule, RouterModule, EmployeeHeaderComponent],
  templateUrl: './view-employees.component.html',
  styleUrls: ['./view-employees.component.scss']
})
export class ViewEmployeesComponent implements OnInit {
  employees: EmployeeListItem[] = [];
  loading = false;
  error = '';

  constructor(private employeeService: EmployeeService) {}

  ngOnInit() {
    this.fetchEmployees();
  }

  fetchEmployees() {
    this.loading = true;
    this.employeeService.viewEmployeesList().subscribe({
      next: (data) => {
        this.employees = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = err.message || 'Failed to load employees';
        console.error(err);
        this.loading = false;
      }
    });
  }
}
