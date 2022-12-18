import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-bike',
  templateUrl: './add-bike.component.html',
  styleUrls: ['./add-bike.component.css']
})
export class AddBikeComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) {}

  addBikeForm!: FormGroup;
  bikeIdRegex = "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";

  ngOnInit(): void {
    this.addBikeForm = this.formBuilder.group({
      bikeId: [null, [Validators.required, Validators.pattern(this.bikeIdRegex)]],
      bikeType: [null, Validators.required]
    });
  }

  submit(): void {
    if (!this.addBikeForm.valid) {
      return;
    }
    console.log(this.addBikeForm.value);
  }
}
