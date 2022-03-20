const element = document.getElementById('errorBox');
const output = element.querySelector('span');


export function notify(msg){
    output.textContent = msg;
    element.style.display = 'block';

    setTimeout(()=> element.style.display = 'none', 3000);
}

window.notify = notify;