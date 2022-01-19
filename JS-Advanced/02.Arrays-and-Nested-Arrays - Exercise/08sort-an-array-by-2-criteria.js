function solve(arr){
    arr = arr.sort((a, b) => a.length - b.length || a.localeCompare(b));

    console.log(arr.join('\n'));
}

solve(['alpha', 
'beta', 
'gamma']
)