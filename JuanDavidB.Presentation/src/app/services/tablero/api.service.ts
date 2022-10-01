import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ITablero, Tablero} from "../../models/tablero";

@Injectable({
  providedIn: 'root'
})

export class ApiService {

  apiUrl: string = 'https://localhost:5001/api/tableros';

  constructor(
    private http: HttpClient
  ) { }

  getTablero(){
    return this.http.get<ITablero>(`${this.apiUrl}`);
  }

  addTablero(resultado:Tablero){
    return this.http.post<Tablero>(`${this.apiUrl}`,resultado)
  }

  updateTablero(id:number,resultado:ITablero){
    return this.http.put<ITablero>(`${this.apiUrl}`+ `/${id}`,resultado);
  }

  deleteResultado(id:number)  {
    return this.http.delete(this.apiUrl + `/${id}`);
  }
}
