import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BikeComponent } from './components/bike/bike.component';
import { UserComponent } from './components/user/user.component';
import { BikeTypeComponent } from './components/bike-type/bike-type.component';
import { LoginComponent } from './login/login/login.component';
import {MatInputModule} from '@angular/material/input';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    BikeComponent,
    UserComponent,
    BikeTypeComponent,
    LoginComponent,
  ],
  imports: [
    AppRoutingModule,
    MatInputModule,
    BrowserModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
