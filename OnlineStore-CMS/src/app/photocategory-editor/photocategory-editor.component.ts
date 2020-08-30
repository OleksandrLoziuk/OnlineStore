import { Component, OnInit, Input } from '@angular/core';
import { Photocategory } from '../_models/Photocategory';

@Component({
  selector: 'app-photocategory-editor',
  templateUrl: './photocategory-editor.component.html',
  styleUrls: ['./photocategory-editor.component.css']
})
export class PhotocategoryEditorComponent implements OnInit {
  @Input() photocategory: string;
  constructor() { }

  ngOnInit() {

 }

}
