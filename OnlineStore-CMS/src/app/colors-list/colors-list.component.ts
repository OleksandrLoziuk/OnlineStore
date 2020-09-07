import { Component, OnInit } from '@angular/core';
import { ColorService } from '../_services/color.service';
import { Color } from '../_models/Color';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-colors-list',
  templateUrl: './colors-list.component.html',
  styleUrls: ['./colors-list.component.scss']
})
export class ColorsListComponent implements OnInit {

  colors: Color[];

  constructor(private colorsService: ColorService, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
      this.loadColors();
  }

  loadColors() {
    this.route.data.subscribe(data => {
      this.colors = data['colors'];
    });
  }

  deleteColor(id: number) {
    this.colorsService.deleteColor(id).subscribe(() => {
        this.alertify.success('Цвет удалён');
        this.colors.splice(this.colors.findIndex(c => c.id === id), 1);
    }, error => {
      this.alertify.error(error);
    });
    
  }

}
