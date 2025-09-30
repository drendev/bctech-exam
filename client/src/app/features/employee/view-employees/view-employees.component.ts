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

  // pagination state
  pageSize = 5;
  currentPage = 1;

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
        this.error = err.error?.message || 'Failed to load employees. Server error.';
        console.error(err);
        this.loading = false;
      }
    });
  }

  // computed employees for current page
  get paginatedEmployees(): EmployeeListItem[] {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    return this.employees.slice(startIndex, startIndex + this.pageSize);
  }

  get totalPages(): number {
    return Math.ceil(this.employees.length / this.pageSize);
  }

  changePage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }
}
