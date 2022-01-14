function solve(n, m){
    while(m){
        let temp = m;
        m = n % m;
        n = temp;
    }

    console.log(n)
}