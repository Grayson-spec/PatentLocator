import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './Components/homepage/homepage.component';
import { SignupComponent } from './Components/signup/signup.component';
import { LoginComponent } from './Components/login/login.component';
import { WelcomepageComponent } from './Components/welcomepage/welcomepage.component';

export const routes: Routes = [
    { path: 'home', component: HomepageComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'login', component: LoginComponent},
    {path: 'welcome', component:WelcomepageComponent},
];

export const appRoutes = RouterModule.forRoot(routes);