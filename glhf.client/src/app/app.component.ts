import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
interface Purchase {
  Id: Number;
  Name: string;
  PurchasedAt: Date;
  Quantity: Number;
  UnitPrice: Number;
  Description: string;
  TotalCost: number;
}




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [DatePipe]
})
export class AppComponent implements OnInit {
  public purchases: Purchase[] = [];
  public test: string = "unset";
  public currentPurchase: Purchase[] = []; //bypassing strict null checks, would rather set a null purchase but w/e

  constructor(private http: HttpClient, public datepipe: DatePipe) {}

  ngOnInit() {
    this.getPurchases();
  }

  getPurchases() {
    this.http.get<Purchase[]>('/api/purchase/getallpurchasestrimmed').subscribe(
      (result) => {
        this.purchases = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  getPurchaseDetails(purchase: Purchase) {
    let response: Purchase;
    this.test = purchase.Name;
    //this.currentPurchase[0] = purchase;
    this.http.get<Purchase>(`/api/purchase/getpurchase?id=${purchase.Id}`).subscribe(
      (result) => {
        this.currentPurchase[0] = result;
      },
        (error) => {
        console.error(error);
        }
    );
    //grab id, use it to find our purchase


  }

  title = 'glhf.client';
}
