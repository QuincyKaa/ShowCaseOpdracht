export default class BoardTile extends HTMLElement {
    constructor(bord) {
        super();
        this.attachShadow({ mode: "open" });
        this.board = bord;
        this.speler =""
        this.applyEventlisteners();
    }

    connectedCallback() {
        this.attachStyling();
        const tile = document.createElement("div");
        tile.setAttribute("class", "board-tile");
        this.shadowRoot.appendChild(tile);
    }

    attachStyling() {
        const linkElem = document.createElement("link");
        linkElem.setAttribute("rel", "stylesheet");
        linkElem.setAttribute("href", "./css/board-tile.css");
        this.shadowRoot.appendChild(linkElem);
    }

    applyEventlisteners() {
        this.addEventListener("click", (event) => {
            if ((!this.shadowRoot.querySelector(".board-tile").classList.contains("occupied")) && (!this.board.IsWin)) {
                if (this.board.moveCount % 2 != 0) {
                    this.shadowRoot.querySelector(".board-tile").classList.add("occupied");
                    this.shadowRoot.querySelector(".board-tile").classList.add("blue");
                    this.board.GameTiles[this.getAttribute("rowid") - 1][this.getAttribute("columnid") - 1] = "blue";
                  this.speler = "circkel"
                  
                    
                }
                else {
                  this.shadowRoot.querySelector(".board-tile").classList.add("occupied");

                    this.shadowRoot.querySelector(".board-tile").classList.add("red");
                    this.board.GameTiles[this.getAttribute("rowid") - 1][this.getAttribute("columnid") - 1] = "red";
                    this.speler = "kruis"
              }
                this.board.moveCount++;
              this.board.checkForWin(this.speler)
              this.board.updateTurnTile();
            }
        })
    }
}
