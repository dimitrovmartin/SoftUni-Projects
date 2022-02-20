function solution(arr) {
    const text = comand();
 
    for (const item of arr) {
        if (item === 'print') {
            text.print();
        }
        else {
            let [command,str] = item.split(' ');
            if (command === 'add') {
                text.add(str);
            }
            else if (command === 'remove') {
                text.remove(str);
            }
        }
    }
    
 function comand() {
     let result = [];
 
     return {
         add,
         remove,
         print
     };
     function add(str) {
         result.push(str);
     }
 
     function remove(str) {
         result = result.filter(x => x !== str);
     }
 
     function print() {
         console.log(result.join(','));
     }
 }
 }
 