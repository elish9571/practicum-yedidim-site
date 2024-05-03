import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../../employee/employee.model';
import { EmployeeService } from '../../employee/employee.service';
import { FormControl, FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormArray } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MatNativeDateModule } from '@angular/material/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
@Component({
  selector: 'app-employee-edit',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatSelectModule,
    MatDatepickerModule,
    ReactiveFormsModule, MatNativeDateModule,
    MatIconModule
  ],
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {
  empToEdit: Employee | undefined;
  empEditForm: FormGroup;
  employeeId: number;
  jobPositions!: FormArray;
  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private route: ActivatedRoute,
    private dialog: MatDialog,
    private employeeService: EmployeeService
  ) {
    this.employeeId = Number(this.route.snapshot.paramMap.get('id'));
    this.empEditForm = this.createForm();
    this.jobPositions = this.empEditForm.get('jobPositions') as FormArray;
  }

  ngOnInit(): void {
    this.loadEmployee(this.employeeId);
  }

  loadEmployee(empId: number): void {
    this.employeeService.getEmployee(empId).subscribe({
      next: (res) => {
        this.empToEdit = res;
        this.empEditForm.patchValue({
          firstName: this.empToEdit.firstName,
          lastName: this.empToEdit.lastName,
          tz: this.empToEdit.tz,
          birthDate: this.empToEdit.birthDate,
          isMale: this.empToEdit.isMale,
          beginningOfWork: this.empToEdit.beginningOfWork,
        });
        this.jobPositionsFormArray.clear();
console.log(this.empToEdit.jobPositions)
        if (this.empToEdit.jobPositions && this.empToEdit.jobPositions.length > 0) {
          this.empToEdit.jobPositions.forEach(job => {
            this.addJobPosition(job);
          });
        }
        this.dateValidator();
      },
      error: (error) => {
        console.error('Error loading employee:', error);
      }
    });
  }

  createForm(): FormGroup {
    return this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      tz: ['', [Validators.required, Validators.pattern(/^\d{9}$/)]],
      birthDate: ['', Validators.required],
      isMale: ['', Validators.required],
      beginningOfWork: ['', Validators.required],
      jobPositions: this.fb.array([])
    });
  }
  addJobPosition(job?: any) {
    const newJobGroup = this.fb.group({
      name: [job ? job.name : '', Validators.required],
      start: [job ? job.start : new Date(), Validators.required], 
      isManagementRole: [job ? job.isManagementRole :'', Validators.required]
    });
    this.jobPositionsFormArray.push(newJobGroup);
  }
  

  onSubmit(): void {
    if (this.empEditForm.valid) {
      const employeeData = this.empEditForm.value;
      this.employeeService.editEmployee(this.employeeId, employeeData).subscribe(
        () => {
          console.log('Employee details updated successfully');
          this.dialog.closeAll();
        },
        error => {
          console.error('Error updating employee details:', error);
        }
      );
    } else {
      // Handle invalid form
    }
  }

  dateValidator(): void {
    const startDate = new Date(this.empEditForm.get('beginningOfWork')?.value);
    const endDate = new Date(this.empEditForm.get('birthDate')?.value);

    if (startDate < endDate) {
      this.empEditForm.get('beginningOfWork')?.setErrors({ invalidStartDate: true });
    } else {
      this.empEditForm.get('beginningOfWork')?.setErrors(null);
    }
  }

  onInputIdChange(event: any): void {
    let sanitizedValue = event.target.value.replace(/\D/g, '');
    if (sanitizedValue.length > 9) {
      sanitizedValue = sanitizedValue.slice(0, 9);
    }
    event.target.value = sanitizedValue;
  }
  get jobPositionsFormArray() {
    return this.empEditForm.get('jobPositions') as FormArray;
  }
  removeJobPosition(index: number) {
    this.jobPositionsFormArray.removeAt(index);
  }
}