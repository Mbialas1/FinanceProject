import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { AddFinanceComponent } from './components/add-finance/add-finance.component';
import { GetFinanceComponent } from './components/get-finance/get-finance.component';
import { DeleteFinanceComponent } from './components/delete-finance/delete-finance.component';
import { StoriesFinancesComponent } from './components/stories-finances/stories-finances.component';
import { AccountBalanceComponent } from './components/account-balance/account-balance.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddFinanceComponent,
    GetFinanceComponent,
    DeleteFinanceComponent,
    StoriesFinancesComponent,
    AccountBalanceComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}