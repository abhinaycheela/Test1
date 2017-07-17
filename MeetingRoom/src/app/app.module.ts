import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { Daterangepicker } from 'ng2-daterangepicker';

@NgModule({
  imports: [BrowserModule,Daterangepicker],
  declarations: [AppComponent],
  bootstrap: [AppComponent]
})

export class AppModule { }