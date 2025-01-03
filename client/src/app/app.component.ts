import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavComponent, HomeComponent],
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  accountService = inject(AccountService); // private ??

  ngOnInit(): void {
      this.setCurrentUser();
  }

  setCurrentUser(){
   const userString = localStorage.getItem('user');
   if(!userString) return;
   const user = JSON.parse(userString);//pretvaranje stringa u json objekat
   this.accountService.currentUser.set(user);
    
  }


 
}
