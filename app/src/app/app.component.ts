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
  ngOnInit(): void {
    this.getCities();
  }

  getCities() {
    this.cityService.get().subscribe((x) => {
      this.cities = x;
    });
  }
  editCity() {
    const dialogRef = this.dialog.open(CityEditComponent, {
      width: '350px',
    });
    dialogRef.afterClosed().subscribe((x) => {
      if (this.cities == undefined) return of();
      return (this.cities = x);
    });
  }
  deleteCity(id: ICities) {
    this.cityService.delete(id).subscribe(() => {
      this.getCities();
    });
  }
}
