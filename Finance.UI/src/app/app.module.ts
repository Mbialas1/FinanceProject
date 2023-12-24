import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { AddFinanceComponent } from './components/add-finance/add-finance.component';
import { StoriesFinancesComponent } from './components/stories-finances/stories-finances.component';
import { AccountBalanceComponent } from './components/account-balance/account-balance.component';

import { ReactiveFormsModule } from '@angular/forms';

///services:
import { JwtInterceptor } from './auth.interceptor';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { TransactionService } from './services/TransactionService';
import { AccountService } from './services/AccountService';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddFinanceComponent,
    StoriesFinancesComponent,
    AccountBalanceComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS, useClass:JwtInterceptor, multi:true
    },
     TransactionService, AccountService],
  bootstrap: [AppComponent],
})
export class AppModule {}