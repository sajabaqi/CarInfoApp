import { Component, OnInit } from '@angular/core';
import { Makes } from '../models/car-make.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MakesService } from '../services/makes-service';
import { VehicleType } from '../models/vehicle-type.model';
import { MakeModel } from '../models/makeModel';
import { NgSelectModule } from '@ng-select/ng-select';

@Component({
  selector: 'app-makes-component',
  standalone: true,
  imports: [CommonModule, FormsModule, NgSelectModule],
  templateUrl: './makes-component.html',
  styleUrl: './makes-component.css'
})
export class MakesComponent implements OnInit {
  makes: Makes[] = [];
  selectedMakeId: number | null = null;
  manufactureYears: number[] = [];
  selectedYear: number | null = null;
  vehicleTypes: VehicleType[] = [];
  makeModels: MakeModel[] = [];
  isLoadingMakes: boolean = false;
  isLoadingTypes: boolean = false;
  isLoadingModels: boolean = false;
  errorMessage: string | null = null;

  constructor(private makesService: MakesService) { }

  ngOnInit(): void {
    this.populateYears();
    this.loadCarMakes();
  }

  populateYears(): void {
    const currentYear = new Date().getFullYear();
    for (let year = currentYear; year >= 1900; year--) {
      this.manufactureYears.push(year);
    }
  }

  loadCarMakes(): void {
    this.isLoadingMakes = true;
    this.errorMessage = null;
    this.makesService.getAllMakes().subscribe({
      next: (response) => {
        this.makes = response;
        this.isLoadingMakes = false;
      },
      error: (err) => {
        console.error('Error loading car makes:', err);
        this.errorMessage = 'Failed to load car makes. Please try again later.';
        this.isLoadingMakes = false;
      }
    });
  }
  onMakeChange(): void {
    this.vehicleTypes = []; // Clear previous vehicle types
    if (this.selectedMakeId) {
      this.loadVehicleTypes(this.selectedMakeId);
      if (this.selectedYear) {
        this.loadMakeModelsByYear(this.selectedMakeId, this.selectedYear);
      }
    }
    
  }
  onMakeYearChange(): void{
    this.makeModels = [];
    if (this.selectedMakeId && this.selectedYear) {
        this.loadMakeModelsByYear(this.selectedMakeId, this.selectedYear);
    }
  }

  loadVehicleTypes(makeId: number): void {
    this.isLoadingTypes = true;
    this.errorMessage = null;
    this.makesService.getVehicleTypesForMake(makeId).subscribe({
      next: (response) => { // تحديد نوع الـ response هنا
        this.vehicleTypes = response;
        this.isLoadingTypes = false;
      },
      error: (err) => {
        console.error('Error loading vehicle types:', err);
        this.errorMessage = 'Failed to load vehicle types. Please try again later.';
        this.isLoadingTypes = false;
      }
    });
  }

  // ... داخل CarSelectorComponent class

  get selectedMakeName(): string {
    const selectedMake = this.makes.find(make => make.make_ID === this.selectedMakeId);
    return selectedMake ? selectedMake.make_Name : "";
  }

loadMakeModelsByYear(makeId: number, modelyear: number): void {
  if(this.selectedMakeId && this.selectedYear) {
    this.isLoadingModels = true;
    this.errorMessage = null;
    this.makesService.getMakeModels(makeId, modelyear).subscribe({
      next: (response) => {
        this.makeModels = response;
        this.isLoadingModels = false;
      },
      error: (err) => {
        console.error('Error loading Models:', err);
        this.errorMessage = 'Failed to load Models. Please try again later.';
        this.isLoadingModels = false;
      }
    });
}
  }

}

