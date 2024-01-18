export const scrollToTop = () => {
    window.scrollTo({ top: 0, behavior: 'auto'});
}

export interface IHourd {
    value: string | number;
    label: string;
    disabled: boolean;
  }
  
  export interface EventListener extends Event, KeyboardEvent {
    target: HTMLInputElement;
    keyCode: number;
  }
  
  export enum ETimePrevios {
    AM = 'am',
    PM = 'pm'
}

  
export function hmsToSecondsOnly(str: string) {
    if (!str) return null;
    var p = str.split(':'),
        s = 0,
        m = 1;
    if (p?.length === 2) {
        p.push('00');
    }
    while (p.length > 0) {
        s += m * parseInt(p.pop() as string, 10);
        m *= 60;
    }
    return s;
}
  
  export function sortTimesStartingFrom(seconds: number, timeArray: any[]) {
    return timeArray.sort(
      (time1: { value: number }, time2: { value: number }) => {
        const adjustedSeconds1 = (time1.value - seconds + 86400) % 86400;
        const adjustedSeconds2 = (time2.value - seconds + 86400) % 86400;
  
        return adjustedSeconds1 - adjustedSeconds2;
      }
    );
  }
  
  export function initTime(
    rangeFrom?: number,
    rangeTo?: number,
    isFrom?: boolean,
    isTo?: boolean,
    minuteControl: number = 5,
    isFilter?: boolean,
    rangeStartTime?: number
  ): IHourd[] {
    let second = -minuteControl * 60;
    let hours = Array(24 * (60 / minuteControl))
      .fill(null)
      .map(() => {
        second += minuteControl * 60;
        return mapTime(second, rangeFrom, rangeTo, isFrom, isTo);
      })
      .filter((item) => (isFilter ? !item.disabled : true));
    if (rangeStartTime || rangeStartTime === 0) {
      hours = sortTimesStartingFrom(rangeStartTime, hours);
    }
    if (isFilter) {
      if (isFrom && rangeTo) {
        hours = hours.filter((item) => (item.value as number) < rangeTo);
      }
  
      if (isTo && rangeFrom) {
        hours = hours.filter((item) => (item.value as number) > rangeFrom);
      }
    }
  
    return hours;
  }
  
  export function formatTime(str: string) {
    const [hourString, minute] = str.split(':');
    const hour = +hourString % 24;
    return (hour % 12 || 12) + ':' + minute + (hour < 12 ? ' am' : ' pm');
  }
  
  export function mapTime(
    second: any,
    rangeFrom?: number,
    rangeTo?: number,
    isFrom?: boolean,
    isTo?: boolean
  ): IHourd {
    if (Number.isInteger(second)) {
        return {
            value: second,
            label: formatTime(
                new Date(second * 1000).toISOString().substring(11, 16)
            ),
            disabled:
                !!(isTo && (rangeFrom ?? 0) >= second) ||
                !!(isFrom && rangeTo && rangeTo <= second)
        };
    }
    if (typeof second === 'string' && !TimeRegex.test(formatTime(second))) {
        return {
            value: second,
            label: second,
            disabled: false
        };
    }
    return {
        value: hmsToSecondsOnly(second) as string | number,
        label: formatTime(second),
        disabled: false
    };
}
export const TimeRegex = /^(0?[0-9]|1[0-2]):[0-5][0-9] (am|pm)$/i;
