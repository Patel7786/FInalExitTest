import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SignUp } from '../sign-up.model';
import { SignUpService } from '../sign-up.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public signupservice:SignUpService,public router:Router) { }

  ngOnInit(): void {
    this.signupservice.getSignUp().subscribe(data=>{
      this.signupservice.listSignUp=data;
    });
  }

  
  submit(form:NgForm)
  {
    for(var i=0;i<this.signupservice.listSignUp.length ;i++)
    {
      if(this.signupservice.listSignUp[i].Email===this.signupservice.SignUpData.Email && this.signupservice.listSignUp[i].Password===this.signupservice.SignUpData.Password)
      {
        localStorage.setItem('userList',JSON.stringify(this.signupservice.SignUpData.Email));
        const oldrecord=localStorage.getItem('userList');
        this.resetform(form);
        if(this.signupservice.listSignUp[i].TypeID==1)
        {
          this.router.navigateByUrl('Admin');
          break;
        }
        else
        { 
        //confirm("Sucessfully Login");
        
        this.router.navigateByUrl('DashBoard');
        break;
        }
      }
    }

    if(i>=this.signupservice.listSignUp.length)
    {
        alert("Please provide Valid Credentials");
    }
  }

  
  

  resetform(myform:NgForm)
  {
    myform.form.reset();
    this.signupservice.SignUpData=new SignUp();
    
  }
}




  


