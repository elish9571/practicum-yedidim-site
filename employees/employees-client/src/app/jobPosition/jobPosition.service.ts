import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JobPosition } from './jobPosition.model';

@Injectable({
  providedIn: 'root'
})
export class JobPositionService {

  private apiUrl = 'https://localhost:7112/api/JobPosition';

  constructor(private http: HttpClient) { }

  addJob(job: JobPosition): Observable<JobPosition> {
    return this.http.put<JobPosition>(this.apiUrl, job);
  }

  deleteJob(idP: number, idE: number): Observable<JobPosition> {
    console.log("dllllllllllllllllll",idP, idE)
    return this.http.delete<JobPosition>(`${this.apiUrl}/${idP}/${idE}`);
  }
  
}
