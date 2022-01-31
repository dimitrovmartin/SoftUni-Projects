function attachEventsListeners() {

    document.getElementById('daysBtn').addEventListener("click",OnClickDays);
    document.getElementById('hoursBtn').addEventListener("click",OnClickHours);
    document.getElementById('minutesBtn').addEventListener("click",OnClickMinutes);
    document.getElementById('secondsBtn').addEventListener("click",OnClickSeconds);
 
    function OnClickDays(event) {
        let days = Number(document.getElementById('days').value);
 
        let hours = document.getElementById('hours').value = days * 24;
        let minutes = document.getElementById('minutes').value = hours * 60;
        let seconds = document.getElementById('seconds').value = minutes * 60;
 
    }
    function OnClickHours(event) {
     let hours = Number(document.getElementById('hours').value);
 
     let days = document.getElementById('days').value = hours / 24;
     let minutes = document.getElementById('minutes').value = hours * 60;
     let seconds = document.getElementById('seconds').value = minutes * 60;
 
 } function OnClickMinutes(event) {
     let minutes = Number(document.getElementById('minutes').value);
 
     let hours = document.getElementById('hours').value = minutes / 60;
     let days = document.getElementById('days').value = hours / 24;
     let seconds = document.getElementById('seconds').value = minutes * 60;
 
 } function OnClickSeconds(event) {
     let seconds = Number(document.getElementById('seconds').value);
 
     let minutes = document.getElementById('minutes').value = seconds / 60;
     let hours = document.getElementById('hours').value = minutes / 60;
     let days = document.getElementById('days').value = hours / 24;
 
 }
 }