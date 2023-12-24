import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NewTransaction } from '../models/NewTransaction';
import { environment } from '../../environments/environment';
import { TransactionModel } from '../models/TransactionModel';

@Injectable({
    providedIn: 'root',
  })

  export class TransactionService {
    private baseUrl = environment.apiBaseUrl;
  
    constructor(private http: HttpClient) {}
  
    addTransaction(newTransaction: NewTransaction): Observable<any> {
      const endpoint = '/finance/addTransaction';
      const url = `${this.baseUrl}${endpoint}`;

      return this.http.post(url, newTransaction);
    }

    getTransactions(lastIdIndex: number): Observable<TransactionModel[]> {
      const url = `${environment.apiBaseUrl}/finance/getFinancesUser/${lastIdIndex}`;
      return this.http.get<TransactionModel[]>(url);
    }

    deleteTransaction(idFinance: number): Observable<any> {
      const url = `${environment.apiBaseUrl}/finance/deleteTransactionById/${idFinance}`;
      return this.http.delete(url);
    }
  }