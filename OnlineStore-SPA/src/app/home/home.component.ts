import { Component, Input, OnInit} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CategoryService } from '../_services/category.service';
import { AlertifyService } from '../_services/alertify.service';
import { Category } from '../_models/category';
import { StringsOrderService } from '../_services/stringsOrder.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  categories: Category[];
  constructor(private router: Router, private categoryService: CategoryService,
    private alertify: AlertifyService, private stringOrder: StringsOrderService) {}
  
  ngOnInit() {
    this.router.navigate(['/categories']);
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
