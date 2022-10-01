import { Component, OnInit } from '@angular/core';
import { ITablero, Tablero } from "../../models/tablero";
import { ApiService } from '../../services/tablero/api.service'

@Component({
  selector: 'app-tablero',
  templateUrl: './tablero.component.html',
  styleUrls: ['./tablero.component.scss']
})
export class TableroComponent implements OnInit {
  _tablero: Tablero = new Tablero();
  datatable: any = [];

  id: number = 0;
  pais: string = "";
  deportista: string = "";
  arranque: number = 0;
  envion: number = 0;
  totalPeso: number = 0;


  constructor(private tableroService: ApiService) { }

  ngOnInit(): void {
    this.onDataTable();
  }

  onDataTable() {
    this.tableroService.getTablero().subscribe(data => {
      this.datatable = data;
    })
  }


  getDataDelete(select: any) {
    this.id = select.id;
    this.deportista = select.deportista;
    this.pais = select.pais;
    this.arranque = select.arranque;
    this.envion = select.envion;
    this.totalPeso = select.total;
    this.onDeleteRecord(this._tablero, this.id);
  }

  getDataEdit(select: any) {
    this._tablero.id = select.id;
    this._tablero.deportista = select.deportista;
    this._tablero.pais = select.pais;
    this._tablero.arranque = select.arranque;
    this._tablero.envion = select.envion;
    this._tablero.totalPeso = select.totalPeso;
  }

  clear() {
    this._tablero.id = 0;
    this._tablero.deportista = '';
    this._tablero.pais = '';
    this._tablero.arranque = 0;
    this._tablero.envion = 0;
    this._tablero.totalPeso = 0;
  }
  onAddRecord(dato: ITablero): void {
    if (dato.pais != "" && dato.deportista != "") {
      this.tableroService.addTablero(dato)
        .subscribe(data => {
          if (data) {
            this.clear();
            this.onDataTable();
          }
        })
    }
  }

  onUpdateRecord(dato: ITablero) {
    if (dato.pais != "" && dato.deportista != "") {
      this.tableroService.updateTablero(dato.id, dato)
        .subscribe(data => {
          if (data) {
            this.clear();
            this.onDataTable();
          }
        })
    }
  }

  onDeleteRecord(dato: ITablero, id: number) {
    this.tableroService.deleteResultado(id)
      .subscribe(data => {
        if (data) {
          this.clear();
          this.onDataTable();
          this.onDataTable();
        }
      })
  }
}
