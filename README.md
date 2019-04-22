# ConsoleCardProject

This is a Visual Studios solution with three projects: SharpDeck (a library found on Github), ConsoleCardProject (game logic), and GameDemo.
This solution is the project I did as an interview application for a full-time position in Wayne, PA.

## Opening

Use Visual Studios

## Usage / Where to Look

Look at the three types of demo, and uncomment (one at a time) the one you want to see. 

```C#
Game game = new Game(DemoSetUp());
Scoreboard scoreboard = new Scoreboard(game);

/* There are three types of demos.
* The first one is fully manual.
* The second two are partially and fully automated. */


//DemoGame(game, scoreboard);

//DemoAutoCompleteRounds(game, scoreboard);

DemoAutoCompleteGame(game, scoreboard);
```


## Other Thoughts

I considered using a queue for the Moves attribute in round; however, that cause problems after all moves have been dequeued, but I need to find the winning move.
I still think a more advanced data structure could have been used, but I had taken plenty of time already, and wanted to submit. 
I also considered but did not code an entire extra layer of abstraction in MaxetaCards so that any deck of card library could be used with the game.
Still, I hope you will find many aspects of this have extensible design.

## License
n/a
