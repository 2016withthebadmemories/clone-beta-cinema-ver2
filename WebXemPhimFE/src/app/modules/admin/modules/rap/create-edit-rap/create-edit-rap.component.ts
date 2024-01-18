import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { RapDto, RapService } from 'src/services/rap.service';

@Component({
  selector: 'app-create-edit-rap',
  templateUrl: './create-edit-rap.component.html',
  styleUrls: ['./create-edit-rap.component.css']
})
export class CreateEditRapComponent {
  public rap: RapDto = {} as RapDto;
  public maRap: any;
  selectedFile!: File;
  constructor(public matDialogRef: MatDialogRef<CreateEditRapComponent>,
    private rapService: RapService,
    @Inject(MAT_DIALOG_DATA) public data: CreateEditRapDialogData) {
  }
  ngOnInit() {
    if (this.data?.rap?.maRap) {
      this.maRap = this.data.rap.maRap;
      this.rap = this.data.rap;
    }
  }
  
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
    }
  
  close() {
    this.matDialogRef.close();
  }

  create() {
    const data: RapDto = {
      maRap: this.rap.maRap,
      tenRap: this.rap.tenRap,
      diaChi: this.rap.diaChi
    };
    if (this.rap.maRap) {
      this.rapService.editRap(data).subscribe(rs => {
        this.close()
      })
    } else {
      this.rapService.createRap(data).subscribe(rs => {
        this.close()
      })
    }
    
  }
}

export interface CreateEditRapDialogData{
  rap: RapDto
}