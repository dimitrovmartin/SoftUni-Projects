function solution(n) {
    let number = Number(n);
    return function (m) {
        let number2 = Number(m);
       return number + number2;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));