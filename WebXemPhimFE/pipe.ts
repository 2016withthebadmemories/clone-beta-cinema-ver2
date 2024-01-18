import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'removeCurrencySymbol'
})
export class RemoveCurrencySymbolPipe implements PipeTransform {
  transform(value: string): string {
    if (value && value.length > 0 && value[0] === '₫') {
      return value.substring(1); // Loại bỏ ký tự đầu tiên
    }
    return value;
  }
}