import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { DepartmentService } from '../../../core/services/department.service';
import { DepartmentByIdResponse } from '../../../core/models/department.model';

@Component({
  selector: 'app-get-department',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './get-department.component.html',
  styleUrls: ['./get-department.component.scss']
})
export class GetDepartmentComponent implements OnInit {
  departmentId!: number;
  department?: DepartmentByIdResponse;
  loading = false;
  error = '';

  constructor(
    private route: ActivatedRoute,
    private departmentService: DepartmentService
  ) {}

  ngOnInit() {
    this.departmentId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.departmentId) {
      this.fetchDepartment();
    } else {
      this.error = 'Invalid Department ID';
    }
  }

  fetchDepartment() {
    this.loading = true;
    this.departmentService.getDepartmentById(this.departmentId).subscribe({
      next: (data) => {
        this.department = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load department';
        this.loading = false;
      }
    });
  }
}
