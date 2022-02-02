import { ICities } from './interface/icities';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CityEditComponent } from './city-edit/city-edit.component';
import { of } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  constructor(public dialog: MatDialog) {}
  displayedColumns: string[] = ['id', 'name', 'action'];
  cities: ICities[] = [
    {
      id: '1',
      name: 'minas',
    },
  ];

  editCity() {
    const dialogRef = this.dialog.open(CityEditComponent, {
      width: '350px',
    });
    dialogRef.afterClosed().subscribe((x) => {
      if(this.cities == undefined) return of();
       return this.cities = x;
    })
  }
}
