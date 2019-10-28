import { Component, OnInit, Input} from '@angular/core';
import { ClickService } from '../_services/click.service';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private clickService: ClickService, private http: HttpClient) {}
  
  ngOnInit() {
  }

  regMode(){
    return this.clickService.getClick();
  }
  
  cancelRegisterMode(registerMode: boolean) {
    this.clickService.setClick(registerMode);
  }

}
