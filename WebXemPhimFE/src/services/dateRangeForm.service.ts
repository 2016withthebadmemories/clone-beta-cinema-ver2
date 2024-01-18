import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { FormControl, FormGroup } from "@angular/forms";

@Injectable({
    providedIn:'root'
})
export class DateRangeFormService {
    range: FormGroup = new FormGroup({});
    constructor(private httpClient: HttpClient) {
    }

    buildForm() {
        this.range = new FormGroup({
            start: new FormControl<Date | null>(null),
            end: new FormControl<Date | null>(null),
        });
    }

    get rangeForm() {
        return this.range.controls;
    }
    get rangeForm_start() {
        return this.rangeForm['start'];
    }
    get rangeForm_end() {
        return this.rangeForm['end'];
    }
}