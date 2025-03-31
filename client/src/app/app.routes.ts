import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './Components/homepage/homepage.component';
import { SignupComponent } from './Components/signup/signup.component';
import { LoginComponent } from './Components/login/login.component';
import { WelcomepageComponent } from './Components/welcomepage/welcomepage.component';
import { AboutComponent } from './Components/about/about.component';
import { AccountComponent } from './Components/account/account.component';
import { PatentdetailsComponent } from './Components/patentdetails/patentdetails.component';
import { ContactComponent } from './Components/contact/contact.component';  
import { AdminComponent } from './Components/admin/admin.component';


export const routes: Routes = [
    { path: '', component: WelcomepageComponent },
    { path: 'home', component: HomepageComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'login', component: LoginComponent },
    { path: 'welcome', component: WelcomepageComponent },
    { path: 'about', component: AboutComponent },
    { path: 'account', component: AccountComponent },
    { path: 'patent', component: PatentdetailsComponent },
    { path: 'contact', component: ContactComponent },  
    { path: 'admin', component: AdminComponent }

];

export const appRoutes = RouterModule.forRoot(routes);
