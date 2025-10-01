import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DepartmentService } from '../../../core/services/department.service';
import { AddDepartment } from '../../../core/models/department.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-department',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.scss']
})
export class AddDepartmentComponent {
  department: AddDepartment = {
    name: '',
    location: '',
  };

  message = '';
  loading = false;
  error = '';

  constructor(private departmentService: DepartmentService, private router: Router) {}

  onSubmit() {
    this.loading = true;
    this.departmentService.addDepartment(this.department).subscribe({
      next: (res) => {
        this.message = res.message || 'Department added successfully!';
        if (res.success) this.router.navigate(['/departments']);
        this.department = { name: '', location: '' };
        this.loading = false;
      },
      error: (err) => {
        this.error = err.error?.message || 'Failed to add department';
        this.loading = false;
      }
    });
  }
}
