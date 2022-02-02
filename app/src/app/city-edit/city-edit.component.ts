import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ICities } from '../interface/icities';

@Component({
  selector: 'ct-city-edit',
  templateUrl: './city-edit.component.html',
  styleUrls: ['./city-edit.component.css']
})
export class CityEditComponent implements OnInit {
  id: string = ''
  name: string = '';
  city = {} as ICities;
  constructor(@Inject(MAT_DIALOG_DATA) public viewCity: ICities) { }

  ngOnInit(): void {
  }
  data(){
    if(this.viewCity)
    this.id = this.viewCity.id;
    this.name = this.viewCity.name;
    return this.viewCity;
  }
}
