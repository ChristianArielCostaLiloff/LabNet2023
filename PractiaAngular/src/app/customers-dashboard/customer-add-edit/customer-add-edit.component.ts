import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CustomersService } from '../services/customers.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Customers } from '../models/customers.interface';
import { CoreService } from '../core/core.service';

@Component({
  selector: 'app-customer-add-edit',
  templateUrl: './customer-add-edit.component.html',
  styleUrls: ['./customer-add-edit.component.css'],
})
export class CustomerAddEditComponent {
  customerForm: FormGroup;
  control: any = {
    isReadOnly: false,
    style: 'background-color:red',
  };

  constructor(
    private _fb: FormBuilder,
    private _customerService: CustomersService,
    private _dialogRef: MatDialogRef<CustomerAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Customers,
    private _coreService: CoreService
  ) {
    this.customerForm = this._fb.group({
      Id: '',
      CompanyName: '',
      ContactName: '',
      City: '',
      Phone: '',
    });
  }

  ngOnInit() {
    this.customerForm.patchValue(this.data);
    this.data
      ? (this.control.isReadOnly = true)
      : (this.control.isReadOnly = false);
  }

  onFormSubmit() {
    if (this.customerForm.valid) {
      if (this.data) {
        this._customerService
          .updateCustomer(this.customerForm.value)
          .subscribe({
            next: (val: any) => {
              this._coreService.openSnackBar('Cliente modificado');
              this._dialogRef.close(true);
            },
            error: (err: any) => {
              console.error(err);
            },
          });
      } else {
        this._customerService.addCustomer(this.customerForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Cliente agregado con exito');
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
    }
  }
}
