function rectangle(width, height, color) {
    color = color[0].toUpperCase() + color.slice(1);

    let obj = {
        width,
        height,
        color,

        calcArea() {
            return this.width * this.height;
        }
    }
    
    return obj;
}