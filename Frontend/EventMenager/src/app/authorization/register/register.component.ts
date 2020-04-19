import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Register } from '../Models/register';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: FormGroup = new FormGroup({
    username: new FormControl('', Validators.required),
    name : new FormControl(''),
    surname : new FormControl(''),
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('', Validators.required),
    birthDate: new FormControl('', Validators.required),
    city: new FormControl('', Validators.required)
  });
  model : Register;
  constructor(public service : AuthService) { 
  
  }

  ngOnInit(): void {
  }

  submit(){
    this.model = this.form.value as Register;
    this.service.register(this.model);
    console.log(this.model);
  }

}
