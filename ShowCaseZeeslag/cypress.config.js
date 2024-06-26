const { defineConfig } = require('cypress');

module.exports = defineConfig({
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
    baseUrl: 'https://localhost:7092/', // Base URL for your application
    specPattern: 'cypress/integration/**/*.cy.{js,jsx,ts,tsx}', // Specify the test file pattern
  },
});
