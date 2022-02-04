import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ICities } from '../interface/icities';

@Component({
  selector: 'ct-city-edit',
  templateUrl: './city-edit.component.html',
  styleUrls: ['./city-edit.component.css'],
})
export class CityEditComponent implements OnInit {
  title: string = 'Editar município';
  city: ICities = {} as ICities;

  constructor(@Inject(MAT_DIALOG_DATA) public data: ICities) {}

  ngOnInit(): void {
    if(this.data) this.city = this.data;
  }

}
