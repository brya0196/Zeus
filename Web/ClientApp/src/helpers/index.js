import moment from "moment";

export function currency(value = 0) {
    return  '$' + parseInt(value)
        .toFixed(1)
        .replace(/(\d)(?=(\d{3})+\.)/g, '$1,')
}
export function date(date, format = 'DD/MM/YYYY') { //h:mm a
    if(!date)
        date = Date.now();
    return moment(date).format(format);
}
export const isEmpty = (value) => {
    return (
        value === undefined ||
        value === null ||
        (typeof value === 'object' && Object.keys(value).length === 0) ||
        (typeof value === 'string' && value.trim().length === 0)
    );
};