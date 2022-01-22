function solve() {
    let arr = [];
    return {
        add(element) {
            arr.push(element);
            this.size++;
            arr.sort((a,b) => a - b);
        },
        remove(index){
            if (index < 0 || index >= arr.length) {
                throw new RangeError('Index out of range');
            }

            arr.splice(index, 1);
            this.size--;
        },
        get(index){
            if (index < 0 || index >= arr.length) {
                throw new RangeError('Index out of range');
            }
            return arr[index];
        },
        size: 0
    }
}