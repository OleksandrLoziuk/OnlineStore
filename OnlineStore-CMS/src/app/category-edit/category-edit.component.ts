import { Component, OnInit, ViewChild, HostListener, Input } from '@angular/core';
import { Category } from '../_models/Category';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriesService } from '../_services/categories.service';
import { AlertifyService } from '../_services/alertify.service';
import { NgForm } from '@angular/forms';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Photocategory } from '../_models/Photocategory';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css']
})
export class CategoryEditComponent implements OnInit {
  @ViewChild('editFrom', {static: false}) editForm: NgForm;
  category: Category;
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;

  constructor(private route: ActivatedRoute, private router: Router, private categoriesService: CategoriesService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.category = data['category'];
    });
    this.initializeUploader();
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'categoriesadmin/' + this.category.id + '/photocategory',
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
        const res: Photocategory = JSON.parse(response);
        const photo = {
          id: res.id,
          url: res.url
        };
        this.category.photoUrl = photo.url;
      }
    }
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }
  editCategory() { 
    this.categoriesService.edit(this.category.id, this.category).subscribe(() => {
      this.alertify.success("Название категории измененно");
      this.editForm.reset(this.category);
    }, error => {
      this.alertify.error(error);
    });
}
  back() {
    this.router.navigate(['/categoriesadmin']);
  }

}
