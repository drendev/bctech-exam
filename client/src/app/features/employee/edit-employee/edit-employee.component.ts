import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { EmployeeService } from '../../../core/services/employee.service';
import { UpdateEmployee } from '../../../core/models/employee.model';

@Component({
  selector: 'app-edit-employee',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.scss']
})
export class EditEmployeeComponent implements OnInit {
  employeeId!: number;
  employee: UpdateEmployee = {
    employeeId: 0,
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
  loading = false;
  error = '';
  response = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService
  ) {}

  ngOnInit() {
    this.employeeId = Number(this.route.snapshot.paramMap.get('id'));
    if (!this.employeeId) {
      this.error = 'Invalid Employee ID';
      return;
    }

    this.employee.employeeId = this.employeeId;

    this.fetchEmployee();
  }

  fetchEmployee() {
    this.loading = true;
    this.employeeService.viewEmployeeById(this.employeeId).subscribe({
      next: (data) => {
        this.employee = { ...this.employee, ...data };
        this.loading = false;
      },
      error: (err) => {
        this.error = err.message || 'Failed to load employee';
        this.loading = false;
      }
    });
  }

  onSubmit() {
    this.loading = true;
    this.employeeService.updateEmployee(this.employee).subscribe({
      next: () => {
        window.alert('Employee updated successfully');
        this.loading = false;
        this.router.navigate(['/employee/view', this.employeeId]); 
      },
      error: (err) => {
        this.response = err.error?.message || 'Update failed';
        this.loading = false;
      }
    });
  }
}
