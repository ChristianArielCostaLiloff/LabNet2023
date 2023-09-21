import { Component, ViewChild } from '@angular/core';

import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';

import { Customers } from '../models/customers.interface';
import { CustomersService } from '../services/customers.service';
import { CustomerAddEditComponent } from '../customer-add-edit/customer-add-edit.component';
import { CoreService } from '../core/core.service';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';

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
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _customerService: CustomersService,
    private _coreService: CoreService,
    private _dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getAllCustomers();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.paginatorTranslation();
  }

  getAllCustomers() {
    this._customerService.getAllCustomers().subscribe({
      next: (res) => {
        this.dataSource.data = res;
      },
      error: (err) => {
        this._coreService.openSnackBar(err.error.Message);
      },
    });
  }

  deleteCustomer(id: string) {
    this._dialog
      .open(ConfirmDialogComponent, { width: '500px', data: id })
      .afterClosed()
      .subscribe({
        next: (value) => {
          if (value) {
            this._customerService.deleteCustomer(id).subscribe({
              next: (res) => {
                this._coreService.openSnackBar(
                  `Cliente con id "${id.trimEnd()}" eliminado`
                );
                this.getAllCustomers();
              },
              error: (err) => {
                this._coreService.openSnackBar(err.error.Message);
              },
            });
          }
        },
      });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
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

  paginatorTranslation() {
    this.paginator._intl.itemsPerPageLabel = 'Elementos por pagina:';
    this.paginator._intl.nextPageLabel = 'Siguiente pagina';
    this.paginator._intl.previousPageLabel = 'Anterior pagina';
  }
}
