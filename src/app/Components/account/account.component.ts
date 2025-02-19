// Accounts Component Class
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  username: string = 'John Doe';
  email: string = 'johndoe@example.com';

  savedPatentCount: number = 3;
  savedPatent1: any = { title: 'Patent 1', filingDate: '2020-01-01', patentNumber: 'US1234567', inventors: 'John Doe, Jane Smith' };
  savedPatent2: any = { title: 'Patent 2', filingDate: '2020-02-01', patentNumber: 'US2345678', inventors: 'Jane Smith, Bob Johnson' };
  savedPatent3: any = { title: 'Patent 3', filingDate: '2020-03-01', patentNumber: 'US3456789', inventors: 'Bob Johnson, Alice Brown' };

  noteCount: number = 3;
  note1: any = { title: 'Note 1', text: 'This is a note.' };
  note2: any = { title: 'Note 2', text: 'This is another note.' };
  note3: any = { title: 'Note 3', text: 'This is yet another note.' };

  recommendation1: any = { title: 'Recommended Patent 1', similarityScore: '0.8', description: 'This patent is similar to your interests.' };
  recommendation2: any = { title: 'Recommended Patent 2', similarityScore: '0.7', description: 'This patent is also similar to your interests.' };
  recommendation3: any = { title: 'Recommended Patent 3', similarityScore: '0.6', description: 'This patent is somewhat similar to your interests.' };

  trend1: any = { technology: 'AI', patentCount: '1000', description: 'Artificial intelligence is a growing field.' };
  trend2: any = { technology: 'Blockchain', patentCount: '500', description: 'Blockchain technology is becoming increasingly popular.' };
  trend3: any = { technology: 'Internet of Things', patentCount: '300', description: 'The Internet of Things is a rapidly expanding field.' };
  trend4: any = { technology: 'Cybersecurity', patentCount: '200', description: 'Cybersecurity is a critical concern in today\'s digital age.' };
  trend5: any = { technology: 'Renewable Energy', patentCount: '100', description: 'Renewable energy sources are becoming increasingly important.' };

  constructor() { }

  ngOnInit(): void { }
}