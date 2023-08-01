# MarvelSnapDeckRandomiser
[Marvel Snap]("https://www.marvelsnap.com/") is an online card game that I've gotten very into over the last year or so. You collect cards of various different Marvel characters, each with unique and varied abilities that synergise 
with other cards, create a deck of 12 of these cards and battle against players online. I'm not really into Marvel but the game is excellent. 

Marvel Snap has a game mode called Battle Mode, that allows you to play against your friends. This is a lot of fun, but the only issue is that sometimes it can be a bit unbalanced. In normal matchmaking, players 
go against other players with a similar collection level (a level that roughly dictates how many cards you have), meaning that people have access to a similar number of cards (higher level cards aren't necessarily better, 
but having more options means you can create much better decks overall). Battle Mode obviously doesn't have this, as you're playing against a specific person you know.

Because of this, whenever me and my friends play, we often decide to make "random" decks by choosing cards using the in game UI to create a deck. This means that no one has a real advantage as the level of synergy between
cards is entirely random. It's a lot of fun! Problem is, making these decks can be a bit faffy and time consuming.

Enter this app. It's just a small thing, but will allow a player to link their in game collection, and it'll create a completely random deck using only cards they currently own. I made it using my normal tech stack of Angular 
and .NET, and used [ElectronNET]("https://github.com/ElectronNET/Electron.NET") to be able to run it easily as a desktop app.

Unfortunately, Marvel Snap doesn't expose a public api, so I'm fairly limited in what can be done in this manner. Currently the app just parses a CollectionState json file that gets updated whenever the game is run but this
only has limited info. If possible, I'd like to be able to separate cards out by Series, energy, power etc. to allow people to play around with making a deck (while still retaining the random nature) but without more 
info that's not really feasible at the moment.
