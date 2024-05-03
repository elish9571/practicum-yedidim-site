import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from './employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private apiUrl = 'https://localhost:7112/api/Employee';

  constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    console.log("get-employees");
    return this.http.get<Employee[]>(this.apiUrl);
  }

  addEmployee(employee: Employee): Observable<any> {
    console.log(employee);
    return this.http.post<any>(this.apiUrl, employee);
  }
  deleteEmployee(id: number): Observable<Employee> {
    return this.http.delete<Employee>(`${this.apiUrl}/${id}`);
  }
  getEmployee(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${id}`);
  }
  editEmployee(id: number, employee: Employee): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, employee);
  }
}

