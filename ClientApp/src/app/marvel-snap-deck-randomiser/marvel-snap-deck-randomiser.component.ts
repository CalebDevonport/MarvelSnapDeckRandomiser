import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-marvel-snap-deck-randomiser',
  templateUrl: './marvel-snap-deck-randomiser.component.html',
  styleUrls: ['./marvel-snap-deck-randomiser.component.scss']
})
export class MarvelSnapDeckRandomiserComponent {
  public deck: DisplayCard[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<DisplayCard[]>(baseUrl + 'deck').subscribe(result => {
      this.deck = result;
    }, error => console.error(error));
  }
}

interface DisplayCard {
  cardName: string;
  picUrl: string;
}
