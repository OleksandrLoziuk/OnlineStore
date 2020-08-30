import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private alertify: AlertifyService, private router: Router, private authService: AuthService) { }
  baseUrl = environment.apiUrl;
  ngOnInit() {
  }

  logout(){ 
    localStorage.removeItem('token');
    this.authService.decodedToken = null;
    this.alertify.success('Пока!');
    this.router.navigate(['/welcomepage']);  
  }

}
