import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Professor } from 'src/app/models/Professor';
import { Util } from 'src/app/util/util';
import { Disciplina } from 'src/app/models/Disciplina';
import { Router } from '@angular/router';

@Component({
  selector: 'app-professores-alunos',
  templateUrl: './professores-alunos.component.html',
  styleUrls: ['./professores-alunos.component.scss']
})
export class ProfessoresAlunosComponent implements OnInit {

  @Input() public professores!: Professor[];
  @Output() closeModal = new EventEmitter();

  constructor(private router: Router) { }

  ngOnInit() {
  }

  disciplinaConcat(disciplinas: Disciplina[]) {
    return Util.nomeConcat(disciplinas);
  }

  professorSelect(prof: Professor) {
    this.closeModal.emit(null);
    this.router.navigate(['/professor', prof.id]);
  }

}
