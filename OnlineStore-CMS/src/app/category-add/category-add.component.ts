import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { CategoriesService } from '../_services/categories.service';
import { AlertifyService } from '../_services/alertify.service';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/Category';



@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html',
  styleUrls: ['./category-add.component.css']
})
export class CategoryAddComponent implements OnInit {
  model: any = {};
  baseUrl = environment.apiUrl;
  req: Category = null;
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  isNameAdded: boolean = false;

  constructor(private router: Router, private categoriesService: CategoriesService, private alertify: AlertifyService) { }

  ngOnInit() {
  }
  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'categoriesadmin/' + this.req.id + '/photocategory',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10*1024*1024
    });
    this.uploader.onAfterAddingFile = (file) => {file.withCredentials = false; };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if(response) {
        this.router.navigate(['/categoriesadmin']);
      }
    }
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  back() {
    this.router.navigate(['/categoriesadmin']);
  }

  addCategory() {
      this.categoriesService.add(this.model).subscribe((data:Category) => {
        this.alertify.success("Катигория добавлена");
        this.req = data;
        this.isNameAdded = true;
        this.initializeUploader();
        
      }, error => {
        this.alertify.error(error);
        this.isNameAdded = false;
      });
  }
 
}
