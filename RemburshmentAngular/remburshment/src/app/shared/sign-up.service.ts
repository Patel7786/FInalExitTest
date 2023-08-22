import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

import { SignUp, SignUpType } from './sign-up.model';

@Injectable({
  providedIn: 'root'
})
export class SignUpService {

  constructor(private myhttp:HttpClient) 
  {
    
  }
  SignUpUrl='https://localhost:44340/api/signup';
  SignUpTypeUrl='https://localhost:44340/api/SignUpTypes';

   listSignUp:SignUp[]=[];
   listSignUpType:SignUpType[]=[];

   SignUpData:SignUp=new SignUp();
   SignUpTypeData:SignUpType=new SignUpType();

  saveSignUp()
   {
     return this.myhttp.post<SignUp>(this.SignUpUrl,this.SignUpData);
   }

   saveSignUpType()
   {
     return this.myhttp.post<SignUpType>(this.SignUpTypeUrl,this.SignUpTypeData);
   }
   getSignUp():Observable<SignUp[]>{
    return this.myhttp.get<SignUp[]>(this.SignUpUrl);
   }

   getSignUpType():Observable<SignUpType[]>{
    return this.myhttp.get<SignUpType[]>(this.SignUpTypeUrl);
   }
   
   getLogin()
   {
    const oldrecord=localStorage.getItem('userList');
    if(oldrecord!=null)
    {
      const userList=JSON.parse(oldrecord);
      return userList;
    }
    return null;
        
   }
}
