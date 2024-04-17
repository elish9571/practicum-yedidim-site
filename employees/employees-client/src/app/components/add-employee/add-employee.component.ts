import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormArray, FormBuilder, ReactiveFormsModule, FormsModule, ValidatorFn } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from '../../employee/employee.service';
import { Employee } from '../../employee/employee.model';
import { MatDatepickerModule, matDatepickerAnimations } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { provideNativeDateAdapter } from '@angular/material/core';
import { NgFor, NgIf } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { FormControl,AbstractControl} from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

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
  ],
  providers: [provideNativeDateAdapter()],
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {

  empForm!: FormGroup;

  constructor(private fb: FormBuilder, private employeeService: EmployeeService, private route: Router) {
    this.empForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      tz: ['', [Validators.required, Validators.minLength(9), Validators.maxLength(9), Validators.pattern('[0-9]*')]],
      beginningOfWork: ['', [Validators.required, this.laterThanValidator]],
      birthDate: ['', [Validators.required]],
      isMale: [true, [Validators.required]],
      jobPositions: this.fb.array([], [Validators.required])
    });
  }
  //   ngOnInit(): void {
  //     if(sessionStorage.getItem('isAuthenticated') != 'true'){
  //       alert('Please login first');
  //       this.route.navigate(['/login']);
  //   }
  // }
  selectedRoles: string[] = [];
  roles = [
    { value: 'vehicles' },
    { value: 'wheels' },
    { value: 'field' },
    { value: 'elevator' }
  ];

  onSubmit() {
    if (true) {
      const employee: Employee = {
        firstName: this.empForm.get('firstName')?.value,
        lastName: this.empForm.get('lastName')?.value,
        tz: this.empForm.get('tz')?.value,
        beginningOfWork: new Date(this.empForm.get('beginningOfWork')?.value),
        birthDate: new Date(this.empForm.get('birthDate')?.value),
        isMale: this.empForm.get('isMale')?.value,
        isDeleted: false,
        jobPositions: this.empForm.get('jobPositions')?.value
      };

      this.employeeService.addEmployee(employee).subscribe({
        next: (res) => {
          console.log('Response:', res);
          alert('Employee added successfully!');
          this.route.navigate(['/allemployees']);
        },
        error: (err) => {
          console.log('Error:', err.message, err.status, err.error);
          alert('An error occurred while adding an employee. Please try again.');
        }
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
  }
 laterThanValidator(startDate: Date): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const selectedDate = control.value;
    if (!selectedDate || !startDate) {
      return null;
    }
    if (selectedDate <= startDate) {
      return { laterThan: true };
    }
    return null; 
  };
}


  addJob() {
    const newJob = this.fb.group({
      name: ['', Validators.required],
      start: ['', Validators.required],
      isManagementRole: [false, Validators.required]
    });

    this.jobPositions.push(newJob);
  }
  deleteJob(index: number) {
    this.jobPositions.removeAt(index);
  }
  get jobPositions() {
    return this.empForm.get('jobPositions') as FormArray;
  }

}
