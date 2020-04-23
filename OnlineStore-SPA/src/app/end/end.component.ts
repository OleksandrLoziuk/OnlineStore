import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-end',
  templateUrl: './end.component.html',
  styleUrls: ['./end.component.css']
})
export class EndComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
    setTimeout( () => {this.router.navigate(['/categories']) }, 5000 );
  }
 
}
