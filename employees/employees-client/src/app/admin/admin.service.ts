import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
private apiUrl = 'https://localhost:7112/api/Admin';
  constructor(private http:HttpClient) { }

  getAdmin(username: string, password: string) {
    const credentials = {
      name: username,
      password: password
    };
    return this.http.get<boolean>(this.apiUrl, { params: credentials }).toPromise();
  }
}

