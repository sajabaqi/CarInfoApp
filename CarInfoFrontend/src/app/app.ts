import { Component } from '@angular/core';
import { MakesComponent } from './makes-component/makes-component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, MakesComponent, FormsModule, NgSelectModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'CarInfoFrontend';
}
