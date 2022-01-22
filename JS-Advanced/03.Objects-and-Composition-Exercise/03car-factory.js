function solve(carRequirements) {
  let engines = [
    { power: 90, volume: 1800 },
    { power: 120, volume: 2400 },
    { power: 200, volume: 3500 },
  ];

  let car = {};

  car.model = carRequirements.model;
  car.engine = engines.filter((x) => x.power >= carRequirements.power)[0];
  car.carriage = {
    type: carRequirements.carriage,
    color: carRequirements.color,
  };
  
  if (carRequirements.wheelsize % 2 == 0){
      carRequirements.wheelsize -= 1;
  }

  car.wheels = [0,0,0,0].fill(carRequirements.wheelsize, 0, 5);

  return car;
}

console.log(solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
))
