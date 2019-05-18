import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  constructor(public auth: AuthService, private alertify: AlertifyService,private router: Router) { }

  ngOnInit() {
  }

  Login() {
    this.auth.login(this.model).subscribe(next => {
      this.alertify.success('Logged in Successfully');
    }, error => {
      this.alertify.error('Failed to Login');
    }, () => {
      this.router.navigate(['/members']);
    });
  }

  LoggedIn() {
    return this.auth.LoggedIn();
  }

  LogOut() {
    localStorage.removeItem('token');
    this.alertify.message('Logged Out');
    this.router.navigate(['/home']);
  }
}
