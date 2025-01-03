import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { inject, Injectable } from '@angular/core';
import { NgIf, TitleCasePipe } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule,BsDropdownModule,RouterLink,RouterLinkActive,TitleCasePipe],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService);
  model: any = {};	
  private router = inject(Router);
  private toastr = inject(ToastrService);
  
  login() 
  {
    this.accountService.login(this.model).subscribe
    ({
        next: () => {
          this.router.navigateByUrl('/members');
        },
        error: error => this.toastr.error(error.error)
    });

  }

  logout()
  {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
