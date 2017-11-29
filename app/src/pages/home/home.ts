import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

import { NovaTurmaPage } from '../turma/nova/nova';
import { EntrarTurmaPage } from '../turma/entrar/entrar';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  novaTurma = NovaTurmaPage;
  entrarTurma = EntrarTurmaPage;

  constructor(public navCtrl: NavController) {

  }
}
