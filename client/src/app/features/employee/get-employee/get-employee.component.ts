import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { EmployeeService } from '../../../core/services/employee.service';
import { Employee } from '../../../core/models/employee.model';

@Component({
  selector: 'app-get-employee',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './get-employee.component.html',
  styleUrls: ['./get-employee.component.scss']
})
export class GetEmployeeComponent implements OnInit {
  employeeId!: number;
  employee?: Employee;
  loading = false;
  error = '';

  constructor(
    private route: ActivatedRoute,
    private employeeService: EmployeeService
  ) {}

  ngOnInit() {
    this.employeeId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.employeeId) {
      this.fetchEmployee();
    } else {
      this.error = 'Invalid Employee ID';
    }
  }

  fetchEmployee() {
    this.loading = true;
    this.employeeService.viewEmployeeById(this.employeeId).subscribe({
      next: (data) => {
        this.employee = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load employee';
        this.loading = false;
      }
    });
  }

  deleteEmployee() {
  if (!this.employee) return;

  const confirmed = confirm(`Are you sure you want to delete ${this.employee.personalInfo.firstName} ${this.employee.personalInfo.lastName}?`);
  if (confirmed) {
    this.employeeService.removeEmployee(this.employeeId).subscribe({
      next: () => {
        alert('Employee deleted successfully.');
        window.location.href = '/';
      },
      error: (err) => {
        alert(err.message || 'Failed to delete employee.');
      }
    });
  }
}

}
