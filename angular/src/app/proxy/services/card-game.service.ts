import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CardGame, CardGameItemDto } from '../models/models';

@Injectable({
  providedIn: 'root',
})
export class CardGameService {
  apiName = 'Default';
  

  calculateScoreByCards = (cards: CardGame[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: '/api/app/card-game/calculate-score',
      body: cards,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/card-game/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, CardGameItemDto[]>({
      method: 'GET',
      url: '/api/app/card-game',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
