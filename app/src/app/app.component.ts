import { CityService } from './service/city.service';
import { ICities } from './interface/icities';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CityEditComponent } from './city-edit/city-edit.component';
import { of } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(public dialog: MatDialog, private cityService: CityService) {}

  displayedColumns: string[] = ['id', 'name', 'action'];
  cities: ICities[] = [];
  city: ICities = {} as ICities;
  ngOnInit(): void {
  }

  getCities() {
    this.cityService.get().subscribe((x) => {
      this.cities = x;
    });
  }
  editCity(city: ICities) {
    const dialogRef = this.dialog.open(CityEditComponent, {
      width: '350px',
      data: city
    });
    dialogRef.afterClosed().pipe(
      switchMap((x : ICities) => {
        if(x == undefined) return of();
        return this.cityService.update(x);
      })
    ).subscribe((x) => {
      console.log(x);
      this.getCities();
    })
  }
  populateTable(){
    this.cityService.populateDatabase(this.city).subscribe(() => {
      this.getCities();
    })
  }
  deleteCity(id: number) {
    this.cityService.delete(id).subscribe(() => {
      console.log(id)
      this.getCities();
    });
  }
  deleteAllDataTable(){
    this.cityService.deleteAll().subscribe(() => {
      this.getCities();
    })
  }
}
