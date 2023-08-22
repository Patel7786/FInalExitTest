import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Currency, DashBoard, remburshment } from './dash-board.model';

@Injectable({
  providedIn: 'root'
})
export class DashBoardService {

  constructor(private myhttp:HttpClient) { }

  
  DashBoardUrl='https://localhost:44340/api/DashboardModels';
  CurrencyUrl='https://localhost:44340/api/CurrencyTypeModels';
  RemburshmentUrl='https://localhost:44340/api/RemburshmentTypeModes';
  MyDashBoardUrl='https://localhost:44340/api/DashboardModels/';
  UpdateUrl='https://localhost:44340/api/getbyIDDashboard/';
  ApproveUrl='https://localhost:44340/api/Approve';
  DeclineUrl='https://localhost:44340/api/Decline'
  listDashBoard:DashBoard[]=[];
  listCurrency:Currency[]=[];
  listRemburshment:remburshment[]=[];
  listMyDashBoard:DashBoard[]=[];
  DashBoardData:DashBoard=new DashBoard();
  UpdateData:DashBoard=new DashBoard();
  ApproveDeclineData:DashBoard=new DashBoard();
  listApproveDecline:DashBoard[]=[];


  saveDashBoard()
   {
     return this.myhttp.post<DashBoard>(this.DashBoardUrl,this.DashBoardData);
   }

   getDashBoard():Observable<DashBoard[]>{
    return this.myhttp.get<DashBoard[]>(this.DashBoardUrl);
   }
   getMyDashBoard():Observable<DashBoard[]>{
    return this.myhttp.get<DashBoard[]>(this.MyDashBoardUrl+`${JSON.parse(localStorage.getItem('userList')!)}`);
   }
   getCurrency():Observable<Currency[]>{
    return this.myhttp.get<Currency[]>(this.CurrencyUrl);
   }

   getRemburshment():Observable<remburshment[]>{
    return this.myhttp.get<remburshment[]>(this.RemburshmentUrl);
   }

   postUpdate(ID:number)
   {
    console.log(this.UpdateData);
    return this.myhttp.post<DashBoard>(this.UpdateUrl,this.UpdateData);
   }

   getUpdate(ID:number):Observable<DashBoard>
   {
    return this.myhttp.get<DashBoard>(this.UpdateUrl+`${ID}`);
   }

   Delete(ID:number)
   {
     return this.myhttp.delete(this.MyDashBoardUrl+`${ID}`);
   }

   getApprove():Observable<DashBoard[]>
   {
      return this.myhttp.get<DashBoard[]>(this.ApproveUrl);
   }

   postApprove()
   {
    return this.myhttp.post<DashBoard>(this.ApproveUrl,this.ApproveDeclineData)
   }

   getDecline():Observable<DashBoard[]>
   {
      return this.myhttp.get<DashBoard[]>(this.DeclineUrl);
   }

   postDecline()
   {
    return this.myhttp.post<DashBoard>(this.DeclineUrl,this.ApproveDeclineData)
   }
}
