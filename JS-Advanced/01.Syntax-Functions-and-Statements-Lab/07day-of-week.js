function solve(day){
    days = {
        'Monday': 1,
        'Tuesday': 2,
        'Wednesday': 3,
        'Thursday': 4,
        'Friday': 5,
        'Saturday': 6,
        'Sunday': 7,
    }

    if (!Object.keys(days).includes(day)){
        return 'error'
    }

    return days[day];
}