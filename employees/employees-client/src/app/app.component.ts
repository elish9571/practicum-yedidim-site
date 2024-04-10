import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeChartComponent } from './components/employee-chart/employee-chart.component';
import { EmployeeEditComponent } from './components/employee-edit/employee-edit.component';
import { HeaderComponent } from './components/header/header.component';
import { AddEmployeeComponent } from "./components/add-employee/add-employee.component";
import { LoginComponent } from './components/login/login.component';
import { AboutComponent } from './components/about/about.component';
@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [
    RouterOutlet,
    EmployeeChartComponent,
    EmployeeEditComponent,
    HeaderComponent,
    AddEmployeeComponent,
    LoginComponent,
    AboutComponent
  ]
})
export class AppComponent {
  title = 'employees';
}
