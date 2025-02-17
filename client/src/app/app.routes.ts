import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './Components/homepage/homepage.component';
import { SignupComponent } from './Components/signup/signup.component';
import { LoginComponent } from './Components/login/login.component';
import { WelcomepageComponent } from './Components/welcomepage/welcomepage.component';
import { AboutComponent } from './Components/about/about.component';
import { AccountComponent } from './Components/account/account.component';
import { PatentdetailsComponent } from './Components/patentdetails/patentdetails.component';

export const routes: Routes = [
    { path: 'home', component: HomepageComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'login', component: LoginComponent},
    {path: 'welcome', component: WelcomepageComponent},
    { path: 'about', component: AboutComponent},
    {path: 'account', component: AccountComponent},
    {path: 'patent', component: PatentdetailsComponent}
];

export const appRoutes = RouterModule.forRoot(routes);