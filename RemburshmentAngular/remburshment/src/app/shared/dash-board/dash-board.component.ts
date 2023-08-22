import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { DashBoardService } from '../dash-board.service';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent implements OnInit {

  constructor(private router:Router,public Dashboardservice:DashBoardService) {
    
   }
   del:any;
  ngOnInit(): void {
    const oldrecord=localStorage.getItem('userList');
    if(oldrecord==null)
    {
      this.router.navigateByUrl('');
    }

    debugger;
    this.Dashboardservice.getMyDashBoard().subscribe(data=>{
      this.Dashboardservice.listMyDashBoard=data;
     
    });
   
    
  }


  RemburshmentForm()
  {
    this.router.navigateByUrl('RemburshmentForm');
  }

  Update(ID:number)
  {
    this.router.navigateByUrl('Update');
  }

  Delete(ID:number)
  {
    console.log(ID);
    
    this.Dashboardservice.Delete(ID).subscribe(
      data => {
        
     this.del=data;
     this.router.navigateByUrl('DashBoard');
    });

   
  }
}
