import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ColorService } from '../_services/color.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-colors-add',
  templateUrl: './colors-add.component.html',
  styleUrls: ['./colors-add.component.scss']
})
export class ColorsAddComponent implements OnInit {
  model: any = {};
 
  constructor(private colorsService: ColorService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }
  addColor(){
      this.colorsService.addColor(this.model).subscribe(() => {
        this.alertify.success('Цвет добавлен');
        this.router.navigate(['/colors']);
      }, error => {
        this.alertify.error(error);
      })
  }
  back() {
    this.router.navigate(['/colors']);
  }

}
