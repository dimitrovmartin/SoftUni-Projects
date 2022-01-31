function lockedProfile() {
    let btns = Array.from(document.getElementsByTagName('button'));

    for (const btn of btns) {
        btn.addEventListener('click',onClick);
    }

    function onClick(ev) {
        let button = ev.target;

        let lock = ev.target.parentNode.getElementsByTagName('input')[0];

        if (!lock.checked) {
            if (button.textContent === 'Show more') {
                button.textContent = 'Hide it';
                button.previousElementSibling.style.display = 'block';

            }
            else if (button.textContent = 'Hide it') {
                button.textContent = 'Show more'
                button.previousElementSibling.style.display = 'none';
            }
        }
    }
}