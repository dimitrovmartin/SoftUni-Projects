function solve(heroes){
    let heroesRegister = [];

    for (const hero of heroes) {
        let [name, level, items] = hero.split(' / ');
        items = items ? items.split(', ') : [];
        level = Number(level);

        heroesRegister.push({name, level, items});
    }

    return JSON.stringify(heroesRegister);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
))