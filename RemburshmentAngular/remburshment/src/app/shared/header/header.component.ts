import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

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


}
