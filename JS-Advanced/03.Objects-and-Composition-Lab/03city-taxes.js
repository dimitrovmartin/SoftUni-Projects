function cityTaxes(name, population, treasury){

    let city = 
    {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes(){
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(precentage){
            this.population += precentage / 100 * this.population;
        },
        applyRecession(precentage){
            this.treasury -= this.treasury * precentage / 100;
        }
    };

    return city;
}

const city =
  cityTaxes('Tortuga',
  7000,
  15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);
