import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, subscribeOn } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root',
  })

  export class AccountService {
    private baseUrl = environment.apiBaseUrl;
  
    constructor(private http: HttpClient) {}

    getAccountBalance(): Observable<string> {
      const endpoint = '/account/balance';
      const url = `${environment.apiBaseUrl}${endpoint}`;
      return this.http.get<string>(url);
    }
  }