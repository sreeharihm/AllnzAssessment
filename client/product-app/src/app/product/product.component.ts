import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {
 
  productList: any;
  constructor(public productService:ProductService) { }

  ngOnInit(): void {
    this.productService.getProduct().subscribe((data: any) => {
      if (data) {
        this.productList = data.productList;
      } 
    });

  }

}
