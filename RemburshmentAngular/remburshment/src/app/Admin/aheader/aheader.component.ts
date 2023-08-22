import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-aheader',
  templateUrl: './aheader.component.html',
  styleUrls: ['./aheader.component.css']
})
export class AHeaderComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  LogOut()
  {
    localStorage.removeItem('userList');
    const oldrecord=localStorage.getItem('userList');
    console.log(oldrecord);
    
    this.router.navigateByUrl('');
  }
  Approve()
  {
    this.router.navigateByUrl('Approve');
  }

  Decline()
  {
    this.router.navigateByUrl('Decline');
  }

}
