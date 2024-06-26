export default class GameStatus extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: "open" });
        this.attachStyling()
    }

    connectedCallback() {
        const div = document.createElement('div');
        div.setAttribute("class", "field");

        // Create a paragraph element to put text
        const tekst = document.createElement('p');
        tekst.textContent = "Turn for:";
        const turnTileDiv = document.createElement("turn-tile-div")
      turnTileDiv.setAttribute("class", "turn-tile");
      turnTileDiv.classList.add("red")


        // Append the paragraph to the div element
        div.appendChild(tekst);
        div.appendChild(turnTileDiv);

        this.shadowRoot.appendChild(div);
    }

    


    attachStyling() {
        const linkElem = document.createElement("link");
        linkElem.setAttribute("rel", "stylesheet");
        linkElem.setAttribute("href", "./css/game-status.css")
        this.shadowRoot.appendChild(linkElem);
    }

}
