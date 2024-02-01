import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Purchase {
  id: Number;
  name: string;
  purchasedAt: Date;
  quantity: Number;
  unitPrice: Number;
  description: string;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public purchases: Purchase[] = [];
  public test: string = "unset";
  public currentPurchase: Purchase[] = []; //bypassing strict null checks, would rather set a null purchase but w/e

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getPurchases();
  }

  getPurchases() {
    this.http.get<Purchase[]>('/api/purchase/getallpurchases').subscribe(
      (result) => {
        this.purchases = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  getPurchaseDetails(purchase: Purchase) {
    this.test = purchase.name;
    this.currentPurchase[0] = purchase;
    //grab id, use it to find our purchase


  }

  title = 'glhf.client';
}
