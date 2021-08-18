function solve(speed, zone){
    let allowedSpeed;
    let status;

    switch (zone) {
        case 'motorway':
            allowedSpeed = 130;
            break;
        case 'interstate':
            allowedSpeed = 90;
            break;
        case 'city':
            allowedSpeed = 50;
            break;
        case 'residential':
            allowedSpeed = 20;
            break;
        default:
            break;
    }

    if (speed > allowedSpeed) {
        if (speed <= allowedSpeed  + 20) {
            status = 'speeding';
        }else if (speed <= allowedSpeed + 40) {
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }

        return `The speed is ${speed - allowedSpeed} km/h faster than the allowed speed of ${allowedSpeed} - ${status}`;
    }
    else{
        return `Driving ${speed} km/h in a ${allowedSpeed} zone`;
    }
}
