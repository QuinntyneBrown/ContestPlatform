import { Component } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'cp-workspace',
  templateUrl: './workspace.component.html',
  styleUrls: ['./workspace.component.scss']
})
export class WorkspaceComponent {

  readonly vm$ = of({ })
  .pipe(
    map(model => ({ model }))
  );

  constructor(

  ) {

  }
}
