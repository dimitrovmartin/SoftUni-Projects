function focused() {
    const rows = document.querySelectorAll('input');

    for (const row of rows) {
        row.addEventListener('focus',onFocus);
        row.addEventListener('blur', onBlur);
    }

    function onFocus(event) {
        event.target.parentNode.className = 'focused';
    }

    function onBlur(event) {
        event.target.parentNode.className = '';
    }
}