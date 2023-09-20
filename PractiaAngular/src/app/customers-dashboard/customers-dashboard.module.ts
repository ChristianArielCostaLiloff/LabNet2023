import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { DashboardComponent } from './dashboard/dashboard.component';
import { CustomersService } from './services/customers.service';
import { CustomerAddEditComponent } from './customer-add-edit/customer-add-edit.component';
import { CoreService } from './core/core.service';

@NgModule({
  declarations: [DashboardComponent, CustomerAddEditComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatToolbarModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatSnackBarModule,
    ReactiveFormsModule,
  ],
  exports: [DashboardComponent],
  providers: [CustomersService, CoreService],
})
export class CustomersDashboardModule {}
