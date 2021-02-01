import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-books',
  templateUrl: './show-books.component.html',
  styleUrls: ['./show-books.component.css']
})
export class ShowBooksComponent implements OnInit {

  constructor(private service:SharedService) { }

  BookList:any=[];

  ngOnInit(): void {
    this.refreshBookList();
  }


  refreshBookList(){
    this.service.getBookList().subscribe(data =>{
      this.BookList=data;
    });
  }

}
