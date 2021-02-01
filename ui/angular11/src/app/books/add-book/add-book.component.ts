import { Component, OnInit, Input } from '@angular/core';
//import { AnyTxtRecord } from 'dns';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() book:any;
  BookId:string;
  BookName:string;
  AuthorName:string;
  ReleaseDate:string;

  ngOnInit(): void {
    this.BookId = this.book.BookId;
    this.BookName = this.book.BookName;
    this.AuthorName = this.book.AuthorName;
    this.ReleaseDate = this.book.ReleaseDate;
  }

  addBook(){

    var val = {BookId:this.BookId,
            BookName:this.BookName,
            AuthorName:this.AuthorName,
            ReleaseDate:this.ReleaseDate};
    this.service.addBook(val).subscribe(res=>{
      alert(res.toString());
    });

  }

  updateBook()  {
    var val = {BookId:this.BookId,
      BookName:this.BookName,
      AuthorName:this.AuthorName,
      ReleaseDate:this.ReleaseDate};
    this.service.updateBook(val).subscribe(res=>{
alert(res.toString());
});

  }



}
