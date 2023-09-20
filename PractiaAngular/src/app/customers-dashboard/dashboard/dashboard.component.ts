import { Component } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { Customers } from '../models/customers.interface';
import { CustomersService } from '../services/customers.service';
import { MatDialog } from '@angular/material/dialog';
import { CustomerAddEditComponent } from '../customer-add-edit/customer-add-edit.component';
import { CoreService } from '../core/core.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent {
  public listCustomers: Array<Customers> = [];
  dataSource: MatTableDataSource<Customers> =
    new MatTableDataSource<Customers>();

  displayedColumns: string[] = [
    'Id',
    'CompanyName',
    'ContactName',
    'City',
    'Phone',
    'Action',
  ];

  constructor(
    private _customerService: CustomersService,
    private _coreService: CoreService,
    private _dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getAllCustomers();
  }

  getAllCustomers() {
    this._customerService.getAllCustomers().subscribe({
      next: (res) => {
        this.dataSource.data = res;
      },
      error: (err) => {
        console.error();
      },
    });
  }

  deleteCustomer(id: string) {
    this._customerService.deleteCustomer(id).subscribe({
      next: (res) => {
        this._coreService.openSnackBar(
          `Cliente con id "${id.trimEnd()}" eliminado`
        );
        this.getAllCustomers();
      },
      error: (err) => {
        console.error();
      },
    });
  }

  openForm() {
    this._dialog
      .open(CustomerAddEditComponent)
      .afterClosed()
      .subscribe({
        next: (value) => {
          if (value) {
            this.getAllCustomers();
          }
        },
      });
  }

  openEditForm(data: Customers) {
    this._dialog
      .open(CustomerAddEditComponent, { data })
      .afterClosed()
      .subscribe({
        next: (value) => {
          if (value) {
            this.getAllCustomers();
          }
        },
      });
  }
}
