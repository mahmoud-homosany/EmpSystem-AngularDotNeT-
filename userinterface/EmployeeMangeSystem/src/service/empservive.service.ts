import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpserviveService {

  private baseUrl = "http://localhost:5268/api/Employee"

  constructor(private http: HttpClient) { }


  getAllEmployees(): Observable<any[]> {
    console.log("Calling API...");
    return this.http.get<any[]>(`${this.baseUrl}`);
  }

  createEmployee(employee: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/create`, employee);
  }

  updateEmployee(employee: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/update`, employee);
  }

  getEmployeeById(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/by-id/${id}`);
  }

  getEmployeeByName(name: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/by-name/${name}`);
  }

  deleteEmployee(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/delete/${id}`);
  }

}
