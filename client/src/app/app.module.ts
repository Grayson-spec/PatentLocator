import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { routes } from './app.routes';

// Traditional Components
import { SignupComponent } from './Components/signup/signup.component';
import { AccountComponent } from './Components/account/account.component';
import { HomepageComponent } from './Components/homepage/homepage.component';
import { WelcomepageComponent } from './Components/welcomepage/welcomepage.component';
import { AboutComponent } from './Components/about/about.component';
import { ContactComponent } from './Components/contact/contact.component';
import { AdminComponent } from './Components/admin/admin.component';

// ✅ Standalone Components
import { LoginComponent } from './Components/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    AccountComponent,
    HomepageComponent,
    WelcomepageComponent,
    AboutComponent,
    ContactComponent,
    AdminComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    LoginComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
