import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CustomersService } from '../services/customers.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Customers } from '../models/customers.interface';
import { CoreService } from '../core/core.service';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-customer-add-edit',
  templateUrl: './customer-add-edit.component.html',
  styleUrls: ['./customer-add-edit.component.css'],
})
export class CustomerAddEditComponent {
  customerForm!: FormGroup;
  isDisabled: boolean = false;

  constructor(
    private _fb: FormBuilder,
    private _customerService: CustomersService,
    private _dialogRef: MatDialogRef<CustomerAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Customers,
    private _coreService: CoreService
  ) {}

  ngOnInit() {
    this.isDisabled = this.data ? true : false;
    this.customerForm = this._fb.group({
      Id: [
        { value: '', disabled: this.isDisabled },
        [Validators.required, Validators.maxLength(5)],
      ],
      CompanyName: ['', [Validators.required, Validators.maxLength(40)]],
      ContactName: ['', [Validators.maxLength(30)]],
      City: ['', [Validators.maxLength(15)]],
      Phone: ['', [Validators.maxLength(24)]],
    });
    this.customerForm.patchValue(this.data);
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
              this._coreService.openSnackBar(err.error.Message);
            },
          });
      } else {
        this._customerService.addCustomer(this.customerForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Cliente agregado con exito');
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            this._coreService.openSnackBar(err.error.Message);
          },
        });
      }
    }
  }

  formValidation(key: string, errorType: string) {
    return (
      this.customerForm.controls[key].hasError(errorType) &&
      (this.customerForm.controls[key].dirty ||
        this.customerForm.controls[key].touched)
    );
  }

}
