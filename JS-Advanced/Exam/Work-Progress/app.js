function solve() {
    let firstNameElement = document.querySelector('#fname');
    let lastNameElement = document.querySelector('#lname');
    let emailElement = document.querySelector('#email');
    let birthElement = document.querySelector('#birth');
    let positionElement = document.querySelector('#position');
    let salaryElement = document.querySelector('#salary');
    let addWorkerbuttonElement = document.querySelector('#add-worker');
    let tbodyElement = document.querySelector('#tbody');
    let sumElement = document.querySelector('#sum');

    addWorkerbuttonElement.addEventListener('click', addWorker);

    function addWorker(e){
        e.preventDefault();
        
        let firstName = firstNameElement.value;
        let lastName = lastNameElement.value;
        let email = emailElement.value;
        let birth = birthElement.value;
        let position = positionElement.value;
        let salary = salaryElement.value;
        
        if (!firstName || !lastName || !email || !birth || !position || !salary || Number.isNaN(Number(salary))){
            return;
        }

        let trElement = document.createElement('tr');

        trElement.innerHTML = `<td>${firstName}</td><td>${lastName}</td><td>${email}</td><td>${birth}</td><td>${position}</td><td>${salary}</td>`
        
        tbodyElement.appendChild(trElement);

        sumElement.textContent = (Number(sumElement.textContent) + Number(salary)).toFixed(2);

        let tdButtonsElement = document.createElement('td');

        let firedButtonElement = document.createElement('button');
        firedButtonElement.textContent = 'Fired'
        firedButtonElement.classList.add('fired');

        let editButtonElement = document.createElement('button');
        editButtonElement.textContent = 'Edit'
        editButtonElement.classList.add('edit');

        editButtonElement.addEventListener('click', edit);
        firedButtonElement.addEventListener('click', fire);

        tdButtonsElement.appendChild(firedButtonElement);
        tdButtonsElement.appendChild(editButtonElement);

        trElement.appendChild(tdButtonsElement);

        function edit(e){
            e.preventDefault();

            let tdElements = e.target.parentElement.parentElement.children;

            firstNameElement.value = tdElements[0].textContent;
            lastNameElement.value = tdElements[1].textContent;
            emailElement.value = tdElements[2].textContent;
            birthElement.value = tdElements[3].textContent;
            positionElement.value= tdElements[4].textContent;
            salaryElement.value = tdElements[5].textContent;

            sumElement.textContent = (Number(sumElement.textContent) - Number(tdElements[5].textContent)).toFixed(2);

            e.target.parentElement.parentElement.remove();
        }

        function fire(e){
            let tdElements = e.target.parentElement.parentElement.children;

            sumElement.textContent = (Number(sumElement.textContent) - Number(tdElements[5].textContent)).toFixed(2);

            e.target.parentElement.parentElement.remove();
        }

        firstNameElement.value = '';
        lastNameElement.value = '';
        emailElement.value = '';
        birthElement.value = '';
        positionElement.value= '';
        salaryElement.value = '';
        addWorkerbuttonElement.value = '';
    }
}
solve()