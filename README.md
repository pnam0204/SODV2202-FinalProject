# SODV2202-FinalProject
## A Single-Player UNO game between user and bot

### Rules:

* Each side start with 7 cards

* An initial card will be played from the deck (except a wild card), no special effect take place even if it's an event card

* Each side can play a card that match the on field card's color or value

* Due to only having 2 players, Reverse card functions like Skip card

* Draw 2 and Draw 4 also skip the opponent's turn after forcing them to draw cards

* No stacking cards

* When no cards on hand can be played, the current player will continuously draw until there's a playable card

* The first side to play all their card wins and the game restart or exist

### Data structure:

UnoCard class contains:

* Color and value property of the card

* GetImagePath method to get the png of the card base on its color and value

UnoDeck class contains:

* 2 lists of UnoCard objects, one for the deck to draw from, one for the discard card after being played

* Deck list is initialize with constructor (for each color: 1 0 card, 2 cards of other values; then 4 wild cards and 4 wild draw 4)

* Discard pile remain blank

* Shuffle method to shuffle the deck after initailization

* Reshuffle call shuffle again to shuffle the discarded pile and add back to deck (except the top/newest card)

* DrawCard remove the card from deck after user or bot has drawn it

* RemainingCards to count how many cards left in the deck

### Algorithm Overview:

* StartGame will initialize the UnoDeck (which contains 2 lists: deck and discardPile) and 2 more lists for playerHand and botHand. Then 7 cards will be drawn for each hand

* NextTurn will decide who can play based on the current player (enum of Human and Bot), if current player is Human then lock player control and call BotAction(), else unlock control so player can move

* NextTurn also check for winning condition (whose hand is emptied) and call EndGame

* EndGame announce the winner then can restart or exit the game with a prompt

* BotAction call smaller helper methods to handle bot moves.
Start with FindValidCard, if there's no valid cards then DrawCards and recheck until there is.
Then PlayBotCard remove the card from botHand and add to discardPile.
Then PlayBotCard process action of special cards (wild color or event card).

* Similar process in player turn in CardPictureBox_Click triggered by clicking a card.
Check if chosen card is playable, if not tell player to choose another card or draw more.
Else PlayPlayerCard remove it from playerHand, add to discardPile, and process special cards.

* Event cards are handled with HandleEventCard which manipulate current player value for turn manipulation before NextTurn is called

* DrawCards can draw multiple cards, which is used when HandleEventCard process draw 2 and draw 4 event

* ChooseRandomColor and ChooseColor are called for bot and player to choose color after playing a wild card

### Micellaneous Methods
* AdjustLayout center the UI onscreen based on window size. Called when game start or whenever window is resized

* UpdateUI update the cards in player and bot's hand after drawing or playing cards

* LockPlayerControl and UnlockPlayerControl to disable and enable player interaction depending on current turn

* ReverseTurnOrder do nothing in 2 player game, only show announcement