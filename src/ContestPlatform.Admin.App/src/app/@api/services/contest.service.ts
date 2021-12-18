import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Contest } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BASE_URL } from '@core';

@Injectable({
  providedIn: 'root'
})
export class ContestService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Contest[]> {
    return this._client.get<{ contests: Contest[] }>(`${this._baseUrl}api/contest`)
      .pipe(
        map(x => x.contests)
      );
  }

  public getById(options: { contestId: string }): Observable<Contest> {
    return this._client.get<{ contest: Contest }>(`${this._baseUrl}api/contest/${options.contestId}`)
      .pipe(
        map(x => x.contest)
      );
  }

  public remove(options: { contest: Contest }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/contest/${options.contest.contestId}`);
  }

  public create(options: { contest: Contest }): Observable<{ contest: Contest }> {
    return this._client.post<{ contest: Contest }>(`${this._baseUrl}api/contest`, { contest: options.contest });
  }
  
  public update(options: { contest: Contest }): Observable<{ contest: Contest }> {
    return this._client.put<{ contest: Contest }>(`${this._baseUrl}api/contest`, { contest: options.contest });
  }
}
