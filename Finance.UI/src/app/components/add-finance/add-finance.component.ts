import { Component, NgModule } from '@angular/core';
import { FormBuilder, FormGroup, NgModel, Validators } from '@angular/forms';
import { TransactionService } from '../../services/TransactionService';

@Component({
  selector: 'app-add-finance',
  templateUrl: './add-finance.component.html',
  styleUrl: './add-finance.component.css'
})
export class AddFinanceComponent {
  financeForm!: FormGroup;
  currentUser = 'TestUser';
  errorMessage: string | null = null;
  successMessage: string | null = null;

  constructor(private fb: FormBuilder, private newTransactionService : TransactionService) {
    this.createForm();
  }

    createForm() {
      this.financeForm = this.fb.group({
        name: ['', Validators.required],
        description: ['', Validators.required],
        amount: [null, [Validators.required, Validators.pattern(/^(-)?\d+(\.\d{1,2})?$/)]],
        currency: ['PLN', Validators.required],
      });
    }

    onSubmit() {
      if (this.financeForm.valid) {
        const financeData = this.financeForm.value;
        this.newTransactionService.addTransaction(financeData).subscribe(
          (result) => {
            console.log('Transaction added successfully. Transaction ID:', result);
            this.financeForm.reset();
            this.successMessage = 'Transaction added successfully. Transaction ID: ' + result;
            this.errorMessage = null;
          },
          (error) => {
            console.error('Error adding transaction:', error);
            this.errorMessage = `Error adding transaction`;
            this.successMessage = null;
          }
        );
      }
    }

}
