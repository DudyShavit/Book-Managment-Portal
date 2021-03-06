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

  ActivateAddEditBookComp:boolean=false;
  book:any;
  ModalTitle:string;

  ngOnInit(): void {
    this.refreshBookList();
  }

  addClick(){
    this.book={
        BookId:0,
        BookName:"",
        AuthorName:"",
        ReleaseDate:""
      }
      this.ModalTitle="Add Book";
      this.ActivateAddEditBookComp = true;
  }

  editClick(item){
    this.book = item;
    this.ModalTitle="Edit Book";
    this.ActivateAddEditBookComp = true;

  }

  closeClick(){
    this.ActivateAddEditBookComp = true;
    this.refreshBookList();

  }
  refreshBookList(){
    this.service.getBookList().subscribe(data =>{
      this.BookList=data;
    });
  }

}
