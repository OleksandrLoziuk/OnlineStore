import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { ClickService } from '../_services/click.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  
  model: any ={};
  registerMode: boolean = false;  
  
  constructor(private authService: AuthService, private clickService: ClickService) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in succesfully');
    }, error => {
      console.log('Failed to login');
    })
  }

  loggedIn(){
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout(){
    localStorage.removeItem('token');
    console.log('logged out');
  }

  registerClick(){
    this.clickService.setClick(this.registerMode = true);

  }

}
