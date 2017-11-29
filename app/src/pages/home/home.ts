import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

import { NovaTurmaPage } from '../turma/nova/nova';
import { EntrarTurmaPage } from '../turma/entrar/entrar';
import { TurmaPage } from '../turma/turma';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  novaTurma = NovaTurmaPage;
  entrarTurma = EntrarTurmaPage;
  turmaPage = TurmaPage;

  constructor(public navCtrl: NavController) {

  }
}
