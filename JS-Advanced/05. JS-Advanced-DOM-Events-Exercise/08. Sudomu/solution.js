function solve() {
    let buttons = document.querySelectorAll("#exercise tfoot button");

    let checkedButton = buttons[0];
    let clearedButton = buttons[1];

    checkedButton.addEventListener('click',chekckBoard);
    clearedButton.addEventListener('click',clear)

    function chekckBoard(e) {
        let board = Array.from(document.querySelectorAll('#exercise tbody tr'))
        .map(row => row.querySelectorAll('input'))
        .map(x => Number(x.value));

        let isValid = isValidSudoko(board);
        let checkParagraph = document.querySelector('#check p');
        let table = document.querySelector('#exercise table');

        table.style.border = isValid ?"2px solid green" :"2px solid red" ;
        checkParagraph.textContent = isValid ? "You solve it! Congratulations!":"NOP! You are not done yet...";
    }

    function isValidSudoko(board) {
        for (let row = 0; row < board.length; row++) {
            let rowValues = {1: 0, 2: 0, 3: 0}
            let colValues = {1: 0, 2: 0, 3: 0}
            for (let col = 0; col < board[row].length; col++) {
                let curRowCell = board[row][col];
                let curColCell = board[col][row];
                
                rowValues[curRowCell]++;
                colValues[curColCell]++;
            }
            let rowVal = Object.values(rowValues);
            let colVal = Object.values(colValues);

            if (rowVal.length > board.length || rowVal.some(x => x !== 1)
            || colVal.length > board.length || colVal.some(x => x !== 1)) {
                return false;
            }
        }
        return true;
    }

    function clear() {
        let checkParagraph = document.querySelector('#check p');
        let table = document.querySelector('#exercise table');
        let board = Array.from(document.querySelectorAll('#exercise tbody tr'))
        .map(row => row.querySelectorAll('input'))
        .map(x => Number(x.value));

    }
}