import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NotifierService } from 'angular-notifier';

interface PostDto {
  id: string
  content: string
  userName: string
  url: string
  reactionsQuantity: number
  commentsQuantity: number
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  post?: PostDto | null;
  isGenerating: boolean = false;

  constructor(private notifierService: NotifierService, private http: HttpClient) {
  }

  generate() {
    this.isGenerating = true;
    this.post = null;

    this.http.get<PostDto>('http://localhost:5000/api/v1/post/random').subscribe({
      next: response => {
        this.post = response;
        this.isGenerating = false;
      },
      error: () => {
        this.isGenerating = false;
      }
    })
  }

  copyText() {
    const element: HTMLDivElement | null = document.querySelector('#content');

    navigator.clipboard.writeText(element?.innerText ?? '').then(() => {
      this.notifierService.notify('success', 'Copied to clipboard successfully!');
    }).catch(() => {
      this.notifierService.notify('danger', 'An error occurred while copying!');
    });
  }
}
