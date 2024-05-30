import BoardTile from "./BoardTile.js";

export default class GameBoard extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: "open" });
        this.tiles = [];
      this.connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();
      this.connection.start()
      this.attachStyling();
      this.addEventListener(this.tiles)
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
        })
                this.tiles.push(boardTile);
                boardColumn.appendChild(boardTile);
                boardRow.appendChild(boardColumn);
            }
           this.shadowRoot.appendChild(boardRow);
       }
    }

  addEventListener(tiles) {

    this.connection.on("ReceiveSetMove", function (symbol, x, y) {//check op niet 2 keer klikken
      tiles.forEach(tile => {
        if ((tile.getAttribute("rowID").toString() == x) && (tile.getAttribute("columnID") == y)) {
          console.log(symbol);
          if (symbol == "x") {
            tile.shadowRoot.querySelector(".board-tile").classList.add("red")
          }
          if (symbol == "o") {
            tile.shadowRoot.querySelector(".board-tile").classList.add("blue")
          }
          console.log(this.connection)
          //dit doet het niet
          this.connection.invoke("ChangeActivePlayer", null)
            .then(() => console.log("ChangeActivePlayer invoked successfully"))
            .catch(error => console.log("Error invoking ChangeActivePlayer:", error));
        
        }
      });      
    });
    this.connection.on("UpdateTurnTile", function () {
      console.log("test")
    })


  }


    /*checkForWin(speler) {
        //aanroepen api
  }*/

  /*updateTurnTile() {
    //aanroepen api met actiefe speler
    const gameStatus = document.querySelector('.screen > game-status');
    const TurnTileDiv = gameStatus.shadowRoot.querySelector(".field").querySelector("turn-tile-div");
    if (*//*actieve speler blauw*//*) {
      TurnTileDiv.classList.remove("red")
      TurnTileDiv.classList.add("blue")
    }
    else {
      TurnTileDiv.classList.remove("blue")
      TurnTileDiv.classList.add("red")
    }
  }*/
    

    attachStyling() {
        const linkElem = document.createElement("link");
        linkElem.setAttribute("rel", "stylesheet");
        linkElem.setAttribute("href", "./css/game-board.css")
        this.shadowRoot.appendChild(linkElem);
    }

}

