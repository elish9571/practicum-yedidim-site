import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Employee } from '../../employee/employee.model';
import { EmployeeService } from '../../employee/employee.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import * as XLSX from 'xlsx';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeEditComponent } from './../employee-edit/employee-edit.component';
import { saveAs } from 'file-saver';

@Component({
   selector: 'app-employees-chart',
   standalone: true,
   imports: [
      MatTableModule,
      MatPaginator,
      FormsModule,
   ],
   templateUrl: './employee-chart.component.html',
   styleUrls: ['./employee-chart.component.css']
})
export class EmployeeChartComponent implements AfterViewInit {

   displayedColumns: string[] = ['lastName', 'firstName', 'tz', 'startDate', 'edit', 'delete'];
   dataSource = new MatTableDataSource<Employee>();
   searchTerm: string = '';

   @ViewChild('searchInput') searchInput!: ElementRef<HTMLInputElement>;
   @ViewChild(MatPaginator) paginator!: MatPaginator;

   constructor(private employeeService: EmployeeService, private route: Router, private elementRef: ElementRef, public dialog: MatDialog) { }
   ngAfterViewInit() {
      this.dataSource.paginator = this.paginator;
      this.loadEmployees();
   }
   loadEmployees() {
      this.employeeService.getEmployees().subscribe(employees => {
         this.dataSource.data = employees;
      });
   }
   editEmployee(employee: Employee) {
      console.log('Edit employee:', employee.id, employee);
      this.route.navigate(['/editemployee', employee.id]);
   }
   deleteEmployee(employeeId: number) {
      if (confirm('Are you sure you want to delete this employee?')) {
         this.employeeService.deleteEmployee(employeeId).subscribe(() => {
            this.loadEmployees();
         }, error => {
            console.error('Failed to delete employee:', error);
         });
      }
   }
   applyFilter() {
      this.dataSource.filter = this.searchTerm.trim().toLowerCase();
   }
   login() {
      this.route.navigate(['/login']);
   }
   exportToExcel(): void {
      const filteredData = this.dataSource.filteredData;
      const excelData = filteredData.map(employee => ({
         'Surname': employee.lastName,
         'Private Name': employee.firstName,
         'ID': employee.tz,
         'Start Date': employee.beginningOfWork
      }));

      const worksheet = XLSX.utils.json_to_sheet(excelData);
      const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
      this.saveAsExcelFile(excelBuffer, 'employees');
   }

   saveAsExcelFile(buffer: any, fileName: string): void {
      const data: Blob = new Blob([buffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8' });
      saveAs(data, `${fileName}_${new Date().getTime()}.xlsx`);
   }

}
