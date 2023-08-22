export class DashBoard 
{
    ID:number;

    Date:Date;
    RequestedValue:number;
    RemburshmentID:number;

    
    RemburshmentType:string;

    CurrencyID:number;
        
    CurrencyType:string;
    Image:string;
    Status:string;

    ApprovedBy:string;

    ApprovedValue:number;
    Note:string;
    Email:string;
}


export class Currency
{
    CurrencyID:number;
    CurrencyType:string;
}


export class remburshment
{
    RemburshmentID:number;
    RemburshmentType:string;
}