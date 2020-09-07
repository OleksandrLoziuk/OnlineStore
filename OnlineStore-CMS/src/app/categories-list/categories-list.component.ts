import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../_services/categories.service';
import { Category } from '../_models/Category';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.css']
})
export class CategoriesListComponent implements OnInit {

  categories: Category[];

  constructor(private categoriesService: CategoriesService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.categories = data['categories'];
    });
    //this.loadCategories();
  }

  /*loadCategories() {
    this.categoriesService.getCategories().subscribe((categories: Category[])=>{
      this.categories = categories;
    }, error => {
      this.alertify.error(error);
    });
  }*/

  deleteCategory(cat: Category) {
    this.categoriesService.deleteCategory(cat.id).subscribe(() => {
      this.categories.splice(this.categories.findIndex(c => c.id === cat.id), 1);
      this.alertify.success('Категория удалена');
    }, error => {
      this.alertify.error(error);
    });
  }

}
