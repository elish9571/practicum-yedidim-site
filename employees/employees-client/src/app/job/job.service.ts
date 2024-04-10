import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Job } from './job.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  private apiUrl = 'https://localhost:7112/api/JobPosition';

  constructor(private http: HttpClient) { }

  addJob(job: Job): Observable<Job> {
    return this.http.put<Job>(this.apiUrl, job);
  }
}
