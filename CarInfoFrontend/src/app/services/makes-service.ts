import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VehicleType } from '../models/vehicle-type.model';
import { Makes } from '../models/car-make.model';
import { MakeModel } from '../models/makeModel';

@Injectable({
  providedIn: 'root'
})
export class MakesService {


  private apiUrl = 'http://localhost:5000/api/makes';

  constructor(private http: HttpClient) { }
  getAllMakes(): Observable<Makes[]> {
    return this.http.get<Makes[]>(`${this.apiUrl}/allMakes`);
  }
  getVehicleTypesForMake(makeId: number): Observable<VehicleType[]> {
    return this.http.get<VehicleType[]>(`${this.apiUrl}/${makeId}/vehicle-types`);
  }
  getMakeModels(makeId: number, modelyear: number): Observable<MakeModel[]> {
    return this.http.get<MakeModel[]>(`${this.apiUrl}/${makeId}/make-model/${modelyear}`);
  }
}

