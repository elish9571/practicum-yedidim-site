import { Component, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { MatFormFieldModule } from '@angular/material/form-field';
import {FormsModule} from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';


@Component({
  selector: 'app-employee-edit',
  standalone: true,
  imports: [
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule, 
    MatFormFieldModule,
    MatInputModule,
    MatMomentDateModule,
    MatFormFieldModule,
    MatInputModule, 
    FormsModule, 
    MatButtonModule, 
    MatIconModule
  ],
  templateUrl: './employee-edit.component.html',
  styleUrl: './employee-edit.component.css'
})
export class EmployeeEditComponent implements AfterViewInit {

  @ViewChild('inputElement') inputElement!: ElementRef;

  startDate = new Date(1990, 0, 1);

  ngAfterViewInit() {
    this.inputElement.nativeElement.addEventListener('focus', () => {
      this.inputElement.nativeElement.parentElement.classList.add('focus');
    });
  }

}
