import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  Validators,
  FormArray,
  FormBuilder,
  ReactiveFormsModule,
  FormsModule,
  ValidatorFn,
} from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from '../../employee/employee.service';
import { Employee } from '../../employee/employee.model';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { provideNativeDateAdapter } from '@angular/material/core';
import { NgFor, NgIf } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { AbstractControl } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormsModule,
    NgFor,
    NgIf,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatSelectModule,
    MatIconModule,
    MatButtonModule,
  ],
  providers: [provideNativeDateAdapter()],
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css'],
})
export class AddEmployeeComponent {
  employee!: Employee;
  empForm!: FormGroup;
  maxJobsCount: number = 4;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private route: Router,
  ) {
    this.empForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      tz: ['', [Validators.required, Validators.pattern('^[0-9]{9}$')]],
      beginningOfWork: ['', [Validators.required]],
      birthDate: ['', [Validators.required]],
      isMale: [[Validators.required]],
      jobPositions: this.fb.array([], [Validators.required]),
    });
    this.empForm.get('birthDate')?.valueChanges.subscribe((value) => {
      this.validateAge(value);
    });
  }
  selectedRoles: string[] = [];
  roles = [{ value: 'vehicles' }, { value: 'wheels' }, { value: 'field' }, { value: 'elevator' }];

  onSubmit() {
    if (this.empForm.valid) {
      const employee: Employee = {
        id: this.empForm.get('id')?.value,
        firstName: this.empForm.get('firstName')?.value,
        lastName: this.empForm.get('lastName')?.value,
        tz: this.empForm.get('tz')?.value,
        beginningOfWork: new Date(this.empForm.get('beginningOfWork')?.value),
        birthDate: new Date(this.empForm.get('birthDate')?.value),
        isMale: this.empForm.get('isMale')?.value,
        isDeleted: false,
        jobPositions: this.empForm.get('jobPositions')?.value,
      };
      // Adding age validation
      this.validateAge(employee.birthDate);
      this.laterThanValidator(employee.jobPositions[0].start);

      this.employeeService.addEmployee(employee).subscribe({
        next: (res) => {
          console.log('Response:', res);
          alert('Employee added successfully!');
          this.route.navigate(['/allemployees']);
        },
        error: (err) => {
          console.log('Error:', err);
          alert('An error occurred while adding an employee. Please try again.');
        },
      });
    } else {
      console.log(this.empForm.value);
      alert('Please fill in all required fields correctly.');
    }
  }
  onInputIdChange(event: any) {
    let sanitizedValue = event.target.value.replace(/\D/g, '');
    if (sanitizedValue.length > 9) {
      sanitizedValue = sanitizedValue.slice(0, 9);
    }
    event.target.value = sanitizedValue;

    this.empForm.get('birthDate')?.valueChanges.subscribe((value) => {
      this.laterThanValidator(value);
    });
  }
  addJob() {
    if (this.jobPositions.length < this.maxJobsCount) {
      const newJob = this.fb.group({
        name: ['', Validators.required],
        start: ['', Validators.required],
        isManagementRole: [Validators.required],
      });
      this.jobPositions.push(newJob);
    } else {
      alert('Maximum job count reached.');
    }
  }
  deleteJob(index: number) {
    this.jobPositions.removeAt(index);
  }
  get jobPositions() {
    return this.empForm.get('jobPositions') as FormArray;
  }

  laterThanValidator(startDate: Date): ValidatorFn {
    console.log('laterThenValidator');
    return (control: AbstractControl): { [key: string]: any } | null => {
      const selectedDate = new Date(control.value);
      if (!selectedDate || !startDate) {
        return null;
      }
      const minStartDate = new Date(startDate);
      minStartDate.setFullYear(minStartDate.getFullYear() + 18);

      if (selectedDate < minStartDate) {
        return { laterThan: true };
      }
      return null;
    };
  }

  validateAge(birthDate: Date): void {
    console.log('validateAge');
    if (birthDate) {
      const today = new Date();
      let age = today.getFullYear() - birthDate.getFullYear();
      const monthDiff = today.getMonth() - birthDate.getMonth();
      if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
        age--;
      }
      if (age < 18) {
        this.empForm.get('birthDate')?.setErrors({ underage: true });
      } else {
        this.empForm.get('birthDate')?.setErrors(null);
      }
    }
  }
  getFormControlError(controlName: string): string {
    const control = this.empForm.get(controlName);
    if (control && control.errors) {
      if (control.errors['required']) {
        return 'This field is required';
      }
      if (control.errors['minlength']) {
        return 'Minimum length is 2 characters';
      }
      if (control.errors['underage']) {
        return 'Volunteer must be 18 years old or older';
      }
      if (control.errors['tooEarly']) {
        return 'Cannot set work start date before the current month';
      }
    }
    return '';
  }
}
