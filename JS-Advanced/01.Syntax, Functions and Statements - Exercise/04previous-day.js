function solve(year, month, day){
    let dateInput = `${year}-${month}-${day}`
    date = new Date(dateInput);
    date.setDate(date.getDate() - 1);
    
    return `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
}

console.log(solve(2016, 9, 30))