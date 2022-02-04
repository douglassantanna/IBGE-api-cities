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
  nome: string = '';
  updateCity: ICities = {} as ICities;
  viewCity: ICities = {} as ICities;

  constructor(@Inject(MAT_DIALOG_DATA) public city: ICities) { }

  ngOnInit(): void {
    if(this.viewCity)
    this.nome = this.viewCity.nome;
    console.log(this.nome)
  }
  data(){
    if(this.viewCity) {
      this.updateCity.id = this.viewCity.id;
      this.updateCity.nome = this.viewCity.nome;
      return this.updateCity;
    }
    return this.viewCity;
  }
}
