import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadComponent: () =>
      import('./components/employee-chart/employee-chart.component').then(
        (c) => c.EmployeeChartComponent,
      ),
  },
  {
    path: 'allemployees',
    loadComponent: () =>
      import('./components/employee-chart/employee-chart.component').then(
        (c) => c.EmployeeChartComponent,
      ),
  },
  {
    path: 'addemployee',
    loadComponent: () =>
      import('./components/add-employee/add-employee.component').then(
        (c) => c.AddEmployeeComponent,
      ),
  },
  {
    path: 'editemployee/:id',
    loadComponent: () =>
      import('./components/employee-edit/employee-edit.component').then(
        (c) => c.EmployeeEditComponent,
      ),
  },
  {
    path: 'login',
    loadComponent: () => import('./components/login/login.component').then((c) => c.LoginComponent),
  },
  {
    path: 'about',
    loadComponent: () => import('./components/about/about.component').then((c) => c.AboutComponent),
  },
];
