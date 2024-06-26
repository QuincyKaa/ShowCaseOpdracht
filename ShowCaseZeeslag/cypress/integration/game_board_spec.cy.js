describe('Game Board', () => {
  let firstRow;

  it("test voor inloggen en een zet doen", () => {
    cy.visit('https://localhost:7092/');
    cy.get('#Input_Email').type('Tester@mail.com');
    cy.get('#Input_Password').type('Test1234!');
    cy.get('#login-submit').click();

    // Wait for the SignalR connection to be established
    cy.wait(500);

    cy.get('.container')
      .find('game-board')
      .shadow()
      .find('.board-row')
      .first()
      .then(($row) => {
        firstRow = $row;

        // Find the first .board-column within firstRow
        const $firstColumn = firstRow.find('.board-column').first();

        // Wait for the board tiles to be loaded

        // Select the first board-tile within the first column
        const $boardTile = $firstColumn.find('board-tile[rowid="0"][columnid="0"]');

        cy.get($boardTile).click();
      });
  });
});
