document.addEventListener("DOMContentLoaded", () => {

    const grid = document.querySelector(".grid");
    const squares = Array.from(grid.querySelectorAll ("div"));
    const displaySquares = document.querySelector(".previous-grid div")
    const width = 10;
    const height = 20;
    let currentPosition = 4;

    //assign function to keycodes
    function control(e){
        if(e.keyCode === 39) {
            moveRight();
        } else if(e.keyCode === 38) {
            rotate();
        } else if(e.keyCode === 37) {
            moveLeft();
        } else if(e.keyCode === 40) {
            moveDown();
        }
    }
    document.addEventListener("keyup", control)


    //#region - Tetrominoes created
    const lTetromino = [
        [1, width + 1, width * 2 + 1, 2],
        [width, width + 1, width + 2, width * 2 + 2],
        [1, width + 1, width * 2 + 1, width * 2],
        [width, width * 2, width * 2 + 1, width * 2 + 2]
    ]

    const zTetromino = [
        [0, width, width + 1, width * 2 + 1],
        [width + 1, width + 2, width * 2, width * 2 + 1],
        [0, width, width + 1, width * 2 + 1],
        [width + 1, width + 2, width * 2, width * 2 + 1]
    ]

    const tTetromino = [
        [1, width, width + 1, width + 2],
        [1, width + 1, width + 2, width * 2 + 1],
        [width, width + 1, width + 2, width * 2 + 1],
        [1, width, width + 1, width * 2 + 1]
    ]

    const oTetromino = [
        [1, width + 1, width * 2 + 1, width * 3 + 1],
        [width, width + 1, width + 2, width + 3],
        [1, width + 1, width * 2 + 1, width * 3 + 1],
        [width, width + 1, width + 2, width + 3]
    ]

    //Add all of them in an array
    const theTetrominoes = [
        lTetromino,
        tTetromino,
        oTetromino,
        zTetromino
    ]

    //#endregion

    let random = Math.floor(Math.random() * theTetrominoes.length);
    let currentRotation = 0;
    let current = theTetrominoes[random][currentRotation];

    //The draw function to create squares
    function draw() {
        current.forEach(index => (squares[currentPosition + index].classList.add("block")))
    }
    function undraw() {
        current.forEach(index => (squares[currentPosition + index].classList.remove("block")))
    }

    //move shapes down
    function moveDown() {
        undraw();
        currentPosition = currentPosition += width;
        draw();
        freeze();
    }

    function moveRight() {
        undraw();
        const isAtRightEdge = current.some(index => (currentPosition + index) % width === width - 1);
        if (isAtRightEdge) {
            currentPosition += 1;
        }
        if (current.some(index => squares[currentPosition + index].classList.contains("block2"))) {
            currentPosition -= 1;
        }
        draw();
    }

    function moveLeft() {
        undraw();
        const isAtLeftEdge = current.some(index => (currentPosition + index) % width === 0);
        if (isAtLeftEdge) {
            currentPosition -= 1;
        }
        if (current.some(index => squares[currentPosition + index].classList.contains("block2"))) {
            currentPosition += 1;
        }
        draw();
    }

    function rotate() {
        undraw();
        currentRotation ++;
        if(currentPosition === current.length) {
            currentRotation = 0;
        }
        current = theTetrominoes[random][currentRotation];
        draw();
    }

})