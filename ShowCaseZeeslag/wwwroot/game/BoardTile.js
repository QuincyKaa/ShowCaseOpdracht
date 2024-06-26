﻿export default class BoardTile extends HTMLElement {
  constructor() {
    super();
    this.attachShadow({ mode: "open" });
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
    let e = new Event("tile-click");
    this.addEventListener("click", (event) => {
      this.dispatchEvent(e);
    });   
  }
}
    
             
    

