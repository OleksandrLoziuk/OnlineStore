import { Component, OnInit } from '@angular/core';
import { Category } from '../_models/category';
import { CategoryService } from '../_services/category.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.css']
})
export class CategoriesListComponent implements OnInit {
 
  categories: Category[];
  
 constructor(private categoryService: CategoryService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadCategories();
  }
  
  loadCategories() {
    this.categoryService.getCategories().subscribe((categories: Category[]) => {
      this.categories = categories;
    }, error => {
      this.alertify.error(error);
    })
  }

}
