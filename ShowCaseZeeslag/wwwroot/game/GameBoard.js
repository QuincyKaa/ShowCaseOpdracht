import BoardTile from "./BoardTile.js";

export default class GameBoard extends HTMLElement {
  constructor() {
    super();
    this.attachShadow({ mode: "open" });
    this.tiles = [];
    this.canTurn = false; 
    this.connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();
    this.connection.start().then(() => {
      this.addListeners();
    });
    this.attachStyling();
  }

  connectedCallback() {
    for (let i = 0; i < this.getAttribute("index"); i++) {
      const boardRow = document.createElement("div");
      boardRow.setAttribute("class", "board-row");

      for (let a = 0; a < this.getAttribute("index"); a++) {
        const boardColumn = document.createElement("div");
        boardColumn.setAttribute("class", "board-column");

        const boardTile = new BoardTile();
        boardTile.setAttribute("rowID", i);
        boardTile.setAttribute("columnID", a);

        boardTile.addEventListener("tile-click", () => {
          this.connection.invoke("SetMove", boardTile.getAttribute("rowID").toString(), boardTile.getAttribute("columnID").toString())
            .then(() => {
              if (this.canTurn) {
                this.connection.invoke("CheckForWinner", "test").then(() => {
                  this.connection.invoke("ChangeActivePlayer", "test")
                })
              }
            })
            .catch(error => {
              console.error(error.toString());
            });
        });

        this.tiles.push(boardTile);
        boardColumn.appendChild(boardTile);
        boardRow.appendChild(boardColumn);
      }
      this.shadowRoot.appendChild(boardRow);
    }
  }

  addListeners() {
    this.connection.on("ReceiveSetMove", (symbol, x, y, isWin) => {
      if (isWin == true) {
        this.canTurn = false;
        return;
      }
      this.tiles.forEach(tile => {
        if ((tile.getAttribute("rowID").toString() == x) && (tile.getAttribute("columnID") == y)) {
          if (!(tile.shadowRoot.querySelector(".board-tile").classList.contains("red")) && !(tile.shadowRoot.querySelector(".board-tile").classList.contains("blue"))) {
            if (symbol == "x") {
              tile.shadowRoot.querySelector(".board-tile").classList.add("red");
              this.canTurn = true;
            } else if (symbol == "o") {
              tile.shadowRoot.querySelector(".board-tile").classList.add("blue");
              this.canTurn = true;
            }
          } else {
            this.canTurn = false;
          }
        }
      });
    });

    this.connection.on("UpdateTurnTile", (symbol) => {
      const gameStatus = document.querySelector('.screen > game-status');
      const TurnTileDiv = gameStatus.shadowRoot.querySelector(".field").querySelector("turn-tile-div");
      if (symbol == "o") {
        TurnTileDiv.classList.remove("red")
        TurnTileDiv.classList.add("blue")
      }
      else if (symbol == "x") {
        TurnTileDiv.classList.remove("blue")
        TurnTileDiv.classList.add("red")
      }
    });

    this.connection.on("CheckedForWinner", (bool, winner) => {
      if (bool) {
        alert(`Speler: ${winner} heeft gewonnen!`);
      }
    })
  }

  attachStyling() {
    const linkElem = document.createElement("link");
    linkElem.setAttribute("rel", "stylesheet");
    linkElem.setAttribute("href", "./css/game-board.css");
    this.shadowRoot.appendChild(linkElem);
  }
}
