function solve(arr){
    arr.sort((a, b) => a.localeCompare(b));

    let counter = 1;

    arr.forEach(name => {
        console.log(`${counter}.${name}`);
        counter++;
    });
}