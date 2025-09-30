import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { EmployeeService } from '../../../core/services/employee.service';
import { Employee } from '../../../core/models/employee.model';
import { Department } from '../../../core/models/department.model';
import { DepartmentService } from '../../../core/services/department.service';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.scss']
})
export class AddEmployeeComponent {
  employee: Employee = {
    jobTitle: '',
    salary: null,
    isActive: true,
    departmentId: null,
    personalInfo: {
      firstName: '',
      lastName: '',
      gender: '',
      address: '',
      phoneNumber: '',
      email: ''
    }
  };
  departments: Department[] = [];
  loading = false;
  response = '';

  constructor(private employeeService: EmployeeService, private router: Router, private departmentService: DepartmentService) {}

  ngOnInit() {
    this.loadDepartments();
  }

  loadDepartments() {
    this.departmentService.viewDepartment().subscribe({
      next: (res) => (this.departments = res.departments),
      error: (err) => console.error('Failed to load departments', err)
    });
  }

  onSubmit() {
    if (!this.employee.jobTitle.trim()) return this.fail('Job Title is required');
    if (!this.employee.personalInfo.firstName.trim()) return this.fail('First Name is required');
    if (!this.employee.personalInfo.lastName.trim()) return this.fail('Last Name is required');
    if (!this.employee.personalInfo.email.trim()) return this.fail('Email is required');

    this.loading = true;
    this.employeeService.addEmployee(this.employee).subscribe({
      next: (res) => {
        this.fail(res.message);
        if (res.response) this.router.navigate(['/']);
      },
      error: (err) => {
        this.fail(err.error?.message || 'Failed to add employee');
        console.error('Add employee failed:', err);
      }
    });
  }

  private fail(message: string) {
    this.response = message;
    this.loading = false;
  }
}
