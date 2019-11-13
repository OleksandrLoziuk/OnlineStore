import { Component, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  categories: any;
  constructor(private http: HttpClient, private router: Router) {}
  
  ngOnInit() {
    this.router.navigate(['/categories']);
    this.getCategories();
  }
  getCategories() {
    this.http.get('http://localhost:5000/api/categories').subscribe(response =>{
      this.categories = response;
    }, error => {
      console.log(error);
    });
  }

}
