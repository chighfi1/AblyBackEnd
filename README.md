If you open swagger, the get call is called automatically by angular on page load. You as a user will enter a message like `"This is a message"` (in quotation marks). When you 
enter, that should trigger the subscription logic in the `this.channel!.subscribe` part of app.component.ts
