import { AuthenticationService } from './../../DataServices/Authentication.service';
import { AuthModel } from 'src/app/Models/Authentication/AuthModel';
import { Component } from '@angular/core';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent {

  authmodel: AuthModel | null;
  constructor(
    private authenticationService: AuthenticationService
  ) {}

  ngOnInit() {
    this.authmodel = this.authenticationService.getAuthData();
  }

  
   


}
