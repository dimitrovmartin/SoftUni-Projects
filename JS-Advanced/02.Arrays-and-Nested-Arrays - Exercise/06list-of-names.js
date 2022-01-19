function solve(arr){
    
    let sortedNames = arr.sort((a, b) => a.localeCompare(b));

    let counter = 1; 

    sortedNames.forEach(element => {
        console.log(`${counter}.${element}`);
        counter++;
    });
}

solve(["John", "Bob", "Christina", "Ema"]
)