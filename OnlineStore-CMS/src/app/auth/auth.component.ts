import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  model: any = {};
  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login(){
      this.authService.login(this.model).subscribe(next => {
        this.alertify.success('Привет! Вход выполнен!');
      }, error => {
        this.alertify.error('Ещё раз ошибёшься, пойдёшь НА ХУЙ!');
      });
  }

}
