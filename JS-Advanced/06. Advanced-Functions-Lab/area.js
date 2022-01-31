function area(area,vol,input) {
    let coordinatesArr = JSON.parse(input);

    let resultArr = [];

    for (const coordinates of coordinatesArr) {
        resultArr.push({
            area: area.call(coordinates),
            volume: vol.call(coordinates),
        })
    }

    return resultArr;
}