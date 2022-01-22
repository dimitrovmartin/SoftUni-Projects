function solve(table) {
    const result = [];

    for (let i = 1; i < table.length; i++) {
        let [_,Town, Latitude, Longitude] = table[i].split(/\s*\|\s*/);

        Latitude = +(Number(Latitude).toFixed(2));
        Longitude = +(Number(Longitude).toFixed(2));


        let obj = {
            Town,
            Latitude,
            Longitude
        };

        result.push(obj);
    }

    return JSON.stringify(result);
}