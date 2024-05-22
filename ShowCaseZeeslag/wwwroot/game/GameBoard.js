import BoardTile from "./BoardTile.js";

export default class GameBoard extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: "open" });
        this.IsWin = false;
        this.tiles = [];
        this.GameTiles = [];
        this.moveCount = 0;
        this.attachStyling()
    }

    connectedCallback() {
       for (let i = 0; i < parseInt(this.getAttribute("index")); i++) {
            const boardRow = document.createElement("div");
           boardRow.setAttribute("class", "board-row");

           //maken Gametiles
           let row = [];
           for (let a = 0; a < parseInt(this.getAttribute("index")); a++) {
                const boardColumn = document.createElement("div");
                boardColumn.setAttribute("class", "board-column");

                const boardTile = new BoardTile(this);
                boardTile.setAttribute("rowID", i+1);
                boardTile.setAttribute("columnID", a + 1);

                this.tiles.push(boardTile);
                boardColumn.appendChild(boardTile);
                boardRow.appendChild(boardColumn);

                //maken Gametiles
                row.push(null);

            }
           this.shadowRoot.appendChild(boardRow);
           this.GameTiles.push(row);
       }
    }

    checkWinHorizontal(tiles, size) {
        // Check horizontal wins
        for (let row = 0; row < size; row++) {
            if (tiles[row][0] && tiles[row].every(cell => cell === tiles[row][0])) {
                return true;
            }
        }
    }

    checkWinVertical(tiles, size) {
        //check vertical wins
        for (let col = 0; col < size; col++) {
            if (tiles[0][col]) {
                let win = tiles.every((row, rowIdx) => {
                    return rowIdx === 0 || row[col] === tiles[0][col];
                });
                if (win) {
                    return true;
                }
            }
        }
    }

    checkWinTopDiaganol(tiles) {
        let firstCell = tiles[0][0];
        if (firstCell) {
            let win = tiles.every((row, idx) => row[idx] === firstCell);
            if (win) {
                return true;
            }
        }
    }
    checkWinBottomDiaganol(tiles, size) {
        let firstCell = tiles[size - 1][0];
        if (firstCell) {
            let win = tiles.every((row, idx) => row[size - 1 - idx] === firstCell);
            if (win) {
                return true;
            }
        }
    }

    checkForWin(speler) {
        const tiles = this.GameTiles;
        const size = tiles.length;

        console.log(this.IsWin);
        if (this.checkWinHorizontal(tiles, size) || this.checkWinVertical(tiles, size) || this.checkWinTopDiaganol(tiles, size) || this.checkWinBottomDiaganol(tiles, size)) {
            this.IsWin = true;
            setTimeout(() => { alert(`spel afgelopen, ${speler} heeft gewonnen!`) }, 250);
        }
    }
    

    attachStyling() {
        const linkElem = document.createElement("link");
        linkElem.setAttribute("rel", "stylesheet");
        linkElem.setAttribute("href", "./css/game-board.css")
        this.shadowRoot.appendChild(linkElem);
    }

}

