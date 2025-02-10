import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenav, MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCheckboxModule } from '@angular/material/checkbox';

@Component({
  selector: 'app-root',
  standalone: true, // ✅ Add this if using Angular standalone components
  imports: [RouterOutlet, RouterLink, MatSidenavModule, MatButtonModule, MatIconModule, MatToolbarModule, MatCheckboxModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'], // ✅ Fixed styleUrls
})
export class AppComponent implements AfterViewInit {
  title = 'ProyectoERP';

  @ViewChild('sidenav') sidenav!: MatSidenav; // ✅ Fix undefined issue

  reason = '';

  ngAfterViewInit() {
    // ViewChild is only available after the view is initialized
  }

  close(reason: string) {
    this.reason = reason;
    this.sidenav.close();
  }
}
