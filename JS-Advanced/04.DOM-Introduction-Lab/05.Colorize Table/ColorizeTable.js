function colorize() {
    let rows = document.
    querySelectorAll("table tr");
  
    let index = 0;
  
  for (let row of rows) {
    index++;
    if (index % 2 == 0)
      row.style.background = "teal";
  }
}
}