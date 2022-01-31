function filter(data, criteria) {
    let employees = JSON.parse(data);

    if (criteria !== 'all') {
        let [criteriaKey, criteriaValue] = criteria.split('-');

        employees = employees.filter(emp => emp[criteriaKey] === criteriaValue);
    }

    let result = [];
    let count = 0;

    employees.map(emp => {
        result.push(`${count++}. ${emp.first_name} ${emp.last_name} - ${emp.email}`);
    });

    console.log(result.join('\n'));
}