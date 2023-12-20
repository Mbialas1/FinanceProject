import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { AddFinanceComponent } from './components/add-finance/add-finance.component';
import { GetFinanceComponent } from './components/get-finance/get-finance.component';
import { DeleteFinanceComponent } from './components/delete-finance/delete-finance.component';
import { StoriesFinancesComponent } from './components/stories-finances/stories-finances.component';
import { AccountBalanceComponent } from './components/account-balance/account-balance.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'add-finance', component: AddFinanceComponent },
  { path: 'get-finance', component: GetFinanceComponent },
  { path: 'delete-finance', component: DeleteFinanceComponent },
  { path: 'stories-finances', component: StoriesFinancesComponent },
  { path: 'account-balance', component: AccountBalanceComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
