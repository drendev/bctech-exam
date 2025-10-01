import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DepartmentService } from '../../../core/services/department.service';
import { Department } from '../../../core/models/department.model';
import { DepartmentHeaderComponent } from "../../../shared/components/department-header/department-header.component";

@Component({
  selector: 'app-view-departments',
  standalone: true,
  imports: [CommonModule, RouterModule, DepartmentHeaderComponent],
  templateUrl: './view-departments.component.html',
  styleUrls: ['./view-departments.component.scss']
})
export class ViewDepartmentsComponent implements OnInit {
  departments: Department[] = [];
  loading = false;
  error = '';

  pageSize = 5;
  currentPage = 1;

  constructor(private departmentService: DepartmentService) {}

  ngOnInit() {
    this.fetchDepartments();
  }

  fetchDepartments() {
    this.loading = true;
    this.departmentService.viewDepartment().subscribe({
      next: (res) => {
        this.departments = res.departments;
        this.loading = false;
      },
      error: (err) => {
        this.error = err.error?.message || 'Failed to load departments. Server error.';
        this.loading = false;
      }
    });
  }

  get paginatedDepartments(): Department[] {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    return this.departments.slice(startIndex, startIndex + this.pageSize);
  }

  get totalPages(): number {
    return Math.ceil(this.departments.length / this.pageSize);
  }

  changePage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }
}
