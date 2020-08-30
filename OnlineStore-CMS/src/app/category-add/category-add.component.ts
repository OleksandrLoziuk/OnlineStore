import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { CategoriesService } from '../_services/categories.service';
import { AlertifyService } from '../_services/alertify.service';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Photocategory } from '../_models/Photocategory';

@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html',
  styleUrls: ['./category-add.component.css']
})
export class CategoryAddComponent implements OnInit {
  model: any = {};
  baseUrl = environment.apiUrl;

  constructor(private router: Router, private categoriesService: CategoriesService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  back() {
    this.router.navigate(['/categoriesadmin']);
  }

  addCategory() {
      this.categoriesService.add(this.model).subscribe(() => {
        this.alertify.success("Катигория добавлена");
        this.router.navigate(['/categoriesadmin']);
      }, error => {
        this.alertify.error(error);
      });
  }
}
