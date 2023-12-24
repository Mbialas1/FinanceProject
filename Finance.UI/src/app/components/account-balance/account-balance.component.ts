import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/AccountService';

@Component({
  selector: 'app-account-balance',
  templateUrl: './account-balance.component.html',
  styleUrl: './account-balance.component.css'
})
export class AccountBalanceComponent {
  accountBalance!: string;

  constructor(private accountService : AccountService){

  }

  ngOnInit(): void {
    this.getAccountBalance();
  }

  getAccountBalance(): void {
    this.accountService.getAccountBalance().subscribe(
      (result) => {
        this.accountBalance = result;
      },
      (error) => {
        console.error('Error fetching account balance:', error);
      }
    );

}
}
