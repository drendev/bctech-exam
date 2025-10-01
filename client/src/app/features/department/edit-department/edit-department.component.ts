import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { DepartmentService } from '../../../core/services/department.service';
import { UpdateDepartment } from '../../../core/models/department.model';

@Component({
  selector: 'app-edit-department',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './edit-department.component.html',
  styleUrls: ['./edit-department.component.scss']
})
export class EditDepartmentComponent implements OnInit {
  departmentId!: number;
  department: UpdateDepartment = {
    departmentId: 0,
    name: '',
    location: ''
  };

  loading = false;
  error = '';
  response = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private departmentService: DepartmentService
  ) {}

  ngOnInit() {
    this.departmentId = Number(this.route.snapshot.paramMap.get('id'));
    if (!this.departmentId) {
      this.error = 'Invalid Department ID';
      return;
    }

    this.department.departmentId = this.departmentId;
    this.fetchDepartment();
  }

  fetchDepartment() {
    this.loading = true;
    this.departmentService.getDepartmentById(this.departmentId).subscribe({
      next: (data) => {
        // your response model wraps the department inside `department`
        this.department = {
          departmentId: this.departmentId,
          name: data.department.name,
          location: data.department.location
        };
        this.loading = false;
      },
      error: (err) => {
        this.error = err.error?.message || 'Failed to load department';
        this.loading = false;
      }
    });
  }

  onSubmit() {
    this.loading = true;
    this.departmentService.updateDepartment(this.department).subscribe({
      next: () => {
        window.alert('Department updated successfully');
        this.loading = false;
        this.router.navigate(['/department/view', this.departmentId]); 
      },
      error: (err) => {
        this.response = err.error?.message || 'Update failed';
        this.loading = false;
      }
    });
  }
}
