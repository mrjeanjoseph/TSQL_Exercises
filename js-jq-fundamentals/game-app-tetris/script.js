document.addEventListener("DOMContentLoaded", () => {

    const startBtn = document.querySelector("button");
    const grid = document.querySelector(".grid");

    const scoreDisplay = document.querySelector(".score-display");
    const linesDisplay = document.querySelector(".lines-display");
    const displaySquares = document.querySelectorAll(".previous-grid div");
    const squares = Array.from(grid.querySelectorAll("div"));
    const width = 10;
    const height = 20;
    let currentPosition = 4;
    let currentIndex = 0;
    let timerId;
    let score = 0;
    let lines = 0

    //assign function to keycodes
    function control(e) {
        if (e.keyCode === 39) {
            moveRight();
        } else if (e.keyCode === 38) {
            rotate();
        } else if (e.keyCode === 37) {
            moveLeft();
        } else if (e.keyCode === 40) {
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
        currentRotation++;
        if (currentPosition === current.length) {
            currentRotation = 0;
        }
        current = theTetrominoes[random][currentRotation];
        draw();
    }

    //show previous tetromino is displaySquares

    const displayWidth = 4;
    const displayIndex = 0;
    let nextRandom = 0;

    const smallTetrominoes = [
        [1, displayWidth + 1, displayWidth * 2 + 1, 2],
        [0, displayWidth, displayWidth + 1, displayWidth * 2 + 1],
        [1, displayWidth, displayWidth + 1, displayWidth + 2],
        [0, 1, displayWidth, displayWidth + 1],
        [1, displayWidth + 1, displayWidth * 2 + 1, displayWidth * 3 + 1]
    ]

    function displayShape() {
        displaySquares.forEach(square => {
            square.classList.remove("block");
        })
        smallTetrominoes[nextRandom].forEach(index => {
            displaySquares[displayIndex + index].classList.add("block");
        })
    }

    function freeze() {
        if (current.some(index => squares[currentPosition + index + width].classList.contains("block3")
            || squares[currentPosition + index + width].classList.contains("block2"))) {
            current.forEach(index => squares[index + currentPosition].classList.add("block2"));

            random = nextRandom;
            nextRandom = Math.floor(Math.random() * theTetrominoes.length)
            current = theTetrominoes[random][currentRotation];
            currentPosition = 4;
            draw();
            displayShape();
            gameOver();
            addScore();
        }
    }

    startBtn.addEventListener("click", () => {
        if (timerId) {
            clearInterval(timerId)
            timerId = null;
        } else {
            draw();
            timerId = setInterval(moveDown, 1000);
            nextRandom = Math.floor(Math.random() * theTetrominoes.length)
            displayShape();
        }
    })

    //Game over
    function gameOver() {
        if (current.some(index => squares[currentPosition + index].classList.contains("block2"))) {
            scoreDisplay.innerHTML = "The End!";
            clearInterval(timerId)
        }
    }

    //add Scores
    function addScore() {
        for (currentIndex = 0; currentIndex < 199; currentIndex += width) {
            const row = [
                currentIndex + 1,
                currentIndex + 2,
                currentIndex + 3,
                currentIndex + 4,
                currentIndex + 5,
                currentIndex + 6,
                currentIndex + 7,
                currentIndex + 8,
                currentIndex + 9,
            ]
            if(row.every(index => squares[index].classList.contains("block2"))) {
                score += 10;
                lines += 1;
                scoreDisplay.innerHTML = score;
                linesDisplay.innerHTML = lines;
                row.forEach(index => {
                    squares[index].classList.remove("block2") || squares[index].classList.remove("block")
                })
                //splice the array
                const squaresRemoved = squares.splice(currentIndex, width);
                squares = squaresRemoved.concat(squares);
                squares.forEach(cell => grid.appendChild(cell)); 
            }
        }
    }

})