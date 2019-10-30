import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { ClickService } from '../_services/click.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  
  model: any ={};
  registerMode: boolean = false;  
  
  constructor(public authService: AuthService, private clickService: ClickService,
    private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in succesfully');
    }, error => {
      this.alertify.error(error);
    })
  }

  loggedIn(){
    return this.authService.loggedIn();
  }

  logout(){
    localStorage.removeItem('token');
    this.alertify.message('logged out');
  }

  registerClick(){
    this.clickService.setClick(this.registerMode = true);

  }

}
