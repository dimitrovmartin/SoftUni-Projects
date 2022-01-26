function attachGradientEvents() {
    let gradientBoxElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    gradientBoxElement.addEventListener('mousemove', gradientMove);
    gradientBoxElement.addEventListener('mouseout', gradientOut);

    function gradientMove(event) {
        let power = event.offsetX / (event.target.clientWidth - 1);
        power = Math.trunc(power * 100);
        resultElement.textContent = power + "%";
    }
    function gradientOut(event) {
        resultElement.textContent = "";
    }
}