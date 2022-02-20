function solution() {
    let result = '';
    let print = function() {
        console.log(result);
    }
    return {
        append: function(text) {
            result += text;
        },
        removeStart(n){
            result = result.substring(n);
        },
        removeEnd: (n) => {
            result = result.substring(0,result.length - n)
        },
        print,
    };
}