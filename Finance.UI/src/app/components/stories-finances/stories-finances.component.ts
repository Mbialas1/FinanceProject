import { Component } from '@angular/core';
import { TransactionModel } from '../../models/TransactionModel';
import { TransactionService } from '../../services/TransactionService';

@Component({
  selector: 'app-stories-finances',
  templateUrl: './stories-finances.component.html',
  styleUrls: ['./stories-finances.component.css']
})
export class StoriesFinancesComponent {

  transactions: TransactionModel[] = [];
  lastId : number = 1;
  hasMoreTransactions : boolean = true;

  constructor(private transactionService : TransactionService){

  }

  ngOnInit(): void {
    this.getTransactions(this.lastId);
  }

  getTransactions(lastIdIndex: number): void {
    this.transactionService.getTransactions(lastIdIndex).subscribe(
      (result) => {
        this.transactions = result;
      },
      (error) => {
        console.error('Error fetching transactions:', error);
      }
    );
  }

  deleteTransaction(idFinance: number): void {
    this.transactionService.deleteTransaction(idFinance).subscribe(
      () => {
        console.log('Transaction deleted successfully.');
        this.transactions = this.transactions.filter(transaction => transaction.id !== idFinance);
      },
      (error) => {
        console.error('Error deleting transaction:', error);
      }
    );
  }

  onMoreTransactionsClick(): void {
    if(this.transactions.length > 0){
    this.lastId = this.transactions[this.transactions.length - 1].id;
    }
    console.log("last id is : " + this.lastId);
    this.loadTransactions();
  }

  loadTransactions(): void {
    this.transactionService.getTransactions(this.lastId).subscribe(
      (data) => {
        this.transactions = this.transactions.concat(data);
        if (data.length === 0) {
          this.hasMoreTransactions = false;
        }
      },
      (error) => {
        console.error('Error loading transactions:', error);
      }
    );
  }

}
