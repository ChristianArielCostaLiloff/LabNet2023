import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customers } from '../models/customers.interface';
import { Environment } from '../environment/environment';

@Injectable({
  providedIn: 'root',
})
export class CustomersService {
  private apiUrl: string = `${Environment.apiLab}customers`;

  constructor(private http: HttpClient) {}

  public getAllCustomers(): Observable<Array<Customers>> {
    return this.http.get<Array<Customers>>(this.apiUrl);
  }

  public addCustomer(data: Customers): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }

  public updateCustomer(data: Customers): Observable<any> {
    return this.http.put(this.apiUrl, data);
  }

  public deleteCustomer(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
