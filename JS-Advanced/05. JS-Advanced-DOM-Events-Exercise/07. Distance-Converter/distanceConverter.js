function attachEventsListeners() {
    document.getElementById('convert').addEventListener('click', function(e) {
        const input = Number(document.getElementById('inputDistance').value);
        const output = document.getElementById('outputDistance');

        const fromUnit = document.getElementById('inputUnits').value;
        const toUnit = document.getElementById('outputUnits').value;
        let unitToM = 0;
        let result = 0;

        switch (fromUnit) {
            case 'km':
                unitToM = input * 1000;
                break;
            case 'm':
                unitToM = input;
                break;
            case 'cm':
                unitToM = input * 0.01;
                break;
            case 'mm':
                unitToM = input * 0.001;
                break;
            case 'mi':
                unitToM = input * 1609.34;
                break;
            case 'yrd':
                unitToM = input * 0.9144;
                break;
            case 'ft':
                unitToM = input * 0.3048;
                break;
            case 'in':
                unitToM = input * 0.0254;
                break;
        }

        switch (toUnit) {
            case 'km':
                result = unitToM / 1000;
                break;
            case 'm':
                result = unitToM;
                break;
            case 'cm':
                result = unitToM / 0.01;
                break;
            case 'mm':
                result = unitToM / 0.001;
                break;
            case 'mi':
                result = unitToM / 1609.34;
                break;
            case 'yrd':
                result = unitToM / 0.9144;
                break;
            case 'ft':
                result = unitToM / 0.3048;
                break;
            case 'in':
                result = unitToM / 0.0254;
                break;
        }
        output.value = result;
    });
}