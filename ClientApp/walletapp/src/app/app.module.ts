import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthenticationService } from './DataServices/Authentication.service';
import { UserProfileComponent } from './Components/user-profile/user-profile.component';
import { AuthGaurd } from './DataServices/guard/auth-guard.service';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { JWT_OPTIONS, JwtHelperService, JwtModule } from '@auth0/angular-jwt';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    UserProfileComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule, 
    RouterModule,
    HttpClientModule,
    JwtModule.forRoot({
      jwtOptionsProvider: {
        provide: JWT_OPTIONS,
        useValue: {
          tokenGetter: () => localStorage.getItem('token'),
        },
      },
    }),
  ],
  providers: [AuthenticationService, AuthGaurd, JwtHelperService],
  bootstrap: [AppComponent]
})
export class AppModule { }
