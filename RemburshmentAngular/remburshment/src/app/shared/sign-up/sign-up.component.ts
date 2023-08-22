import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SignUp } from '../sign-up.model';
import { SignUpService } from '../sign-up.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})

export class SignUPComponent implements OnInit {

  constructor(public signupservice:SignUpService,private router:Router) { }


  ngOnInit(): void {
    this.signupservice.getSignUpType().subscribe(d =>{
      this.signupservice.listSignUpType=d
    });
    this.signupservice.getSignUp().subscribe(data=>{
      this.signupservice.listSignUp=data;
    });
      
      
    }
  submit(form:NgForm)
  {
    for(var i=0;i<this.signupservice.listSignUp.length ;i++)
    {
      if(this.signupservice.listSignUp[i].Email===this.signupservice.SignUpData.Email)
      {
        alert("Email Exist");
        break;
      }
    }
    if(i>=this.signupservice.listSignUp.length)
    {
      this.insertSignUp(form);
    }
   
  }

  insertSignUp(myform:NgForm)
  {
    this.signupservice.saveSignUp().subscribe(d=>{
      this.resetform(myform);
      
    });
  }

  resetform(myform:NgForm)
  {
    myform.form.reset();
    this.signupservice.SignUpData=new SignUp();
    this.router.navigateByUrl('');
  }

  Back()
  {
    this.router.navigateByUrl('');
  }
  
}
