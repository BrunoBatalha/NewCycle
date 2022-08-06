import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NotifierModule } from 'angular-notifier';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    NotifierModule.withConfig({
      behaviour: {
        autoHide: 3000,
      },
      position: {
        horizontal: {
          position: 'left'
        },
        vertical: {
          position: 'top'
        }
      },

    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
