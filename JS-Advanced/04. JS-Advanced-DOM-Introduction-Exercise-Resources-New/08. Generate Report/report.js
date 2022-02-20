function generateReport() {
    const headers = Array.from(document.querySelectorAll('th')).map(h => h.children[0]);

    const rows = Array.from(document.querySelectorAll('tbody tr'));

    let result = [];

    rows.forEach(row => {
        let currRow = Array.from(row.children).reduce((acc,prop, index) =>{

            if (headers[index].checked) {
                let headerName = headers[index].name;
                acc[headerName] = prop.innerText;
            }

            return acc;
        }, {});
        result.push(currRow);
    });

    document.querySelector('#output').value = JSON.stringify(result);
}