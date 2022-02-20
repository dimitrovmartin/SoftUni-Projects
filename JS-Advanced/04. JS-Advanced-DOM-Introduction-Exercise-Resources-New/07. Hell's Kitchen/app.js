function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let inputElement = document.querySelector('#inputs textarea');
      let restaurants = JSON.parse(inputElement.value);

      const restaurantsObj = {};

      for (const e of restaurants) {


         const [restaurantName, restaurantData] = e.split(' - ');
         const workersData = restaurantData.split(', ');

         let workers = [];

         for (const data of workersData) {
            const [name, salary] = data.split(' ');

            const worker = {
               name,
               salary,
            }

            workers.push(worker);
         }

         if (restaurantsObj[restaurantName]) {
            workers = workers.concat(restaurantsObj[restaurantName].workers);
         };

         workers.sort((a, b) => b.salary - a.salary);

         const avgSalary = workers.reduce((sum, worker) => sum + Number(worker.salary), 0) / workers.length;

         const bestSalary = Number(workers[0].salary);


         restaurantsObj[restaurantName] = {
            workers,
            avgSalary,
            bestSalary,
         }
      };

      let bestName = undefined;
       let bestSalary = 0;

       for (const restaurant in restaurantsObj) {
           let currAvgSalary = restaurantsObj[restaurant].avgSalary;

           if (restaurantsObj[restaurant].avgSalary > bestSalary) {
               bestSalary = currAvgSalary;
               bestName = restaurant;
           }
       }

       const bestRestaurant = restaurantsObj[bestName];

       const restaurantOutput = document.querySelector('#bestRestaurant>p');

       restaurantOutput.textContent =
           `Name: ${bestName} Average Salary: ${bestRestaurant.avgSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

       const workersOutput = document.querySelector('#workers>p');

       let workersText = [];

       bestRestaurant.workers.forEach(w => {
           workersText.push(`Name: ${w.name} With Salary: ${w.salary}`)
       });


       workersOutput.textContent = workersText.join(' ');
   }
}