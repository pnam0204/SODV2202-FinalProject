using SODV2202_FinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SODV2202_FinalProject
{
    public partial class Game : Form
    {
        private UnoDeck deck;
        private List<UnoCard> playerHand, botHand;
        private UnoCard currentCard;
        private string wildColor; //This hold the choosen color of the previous wild card played
        private enum Player { Human, Bot}
        private Player currentPlayer;
        public Game()
        {
            InitializeComponent();
            adjustLayout();

            StartGame();
        }
        private void adjustLayout()
        {
            // Center lblStatus at the top
            lblStatus.Left = (this.ClientSize.Width - lblStatus.Width) / 2;
            lblStatus.Top = 25;

            // Center flpBotHand under lblStatus
            flpBotHand.Left = (this.ClientSize.Width - flpBotHand.Width) / 2;
            flpBotHand.Top = lblStatus.Bottom + 20; // Add some spacing below lblStatus

            // Center the FlowLayoutPanel for the player's hand at the bottom
            flpPlayerHand.Left = (this.ClientSize.Width - flpPlayerHand.Width) / 2;
            flpPlayerHand.Top = this.ClientSize.Height - flpPlayerHand.Height - 50;

            // Center the discard and draw pile (contained in a panel)
            DiscardAndDraw.Left = (this.ClientSize.Width - DiscardAndDraw.Width) / 2;
            DiscardAndDraw.Top = (this.ClientSize.Height - DiscardAndDraw.Height) / 2;
        }
        private void StartGame()
        {
            wildColor = "Wild";
            deck = new UnoDeck();
            playerHand = new List<UnoCard>();
            botHand = new List<UnoCard>();
            // Draw 7 cards for the player
            for (int i = 0; i < 7; i++)
            {
                playerHand.Add(deck.DrawCard());
                botHand.Add(deck.DrawCard());
            }
            // Set the first card on the discard pile, redraw if it's a wild card
            do
            {
                currentCard = deck.DrawCard();
                deck.discardPile.Add(currentCard);
            } while (currentCard.Color == "Wild");

            currentPlayer = Player.Human;
            UpdateUI();
            UnlockPlayerControls();
        }
        private void EndGame(string winner)
        {
            // Display the winner
            MessageBox.Show($"{winner} wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Disable player's controls
            LockPlayerControls();
            // Restart or exit the game
            DialogResult result = MessageBox.Show("Would you like to play again?", "Restart", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                StartGame(); // Restart the game
            }
            else
            {
                Application.Exit(); // Close the application
            }
        }
        private void NextTurn()
        {
            UpdateUI();
            if (playerHand.Count == 0)
            {
                EndGame("Player");
                return;
            }
            if (botHand.Count == 0)
            {
                EndGame("Bot");
                return;
            }
            if (currentPlayer == Player.Human)
            {
                currentPlayer = Player.Bot;
                LockPlayerControls();
                BotAction();
            }
            else
            {
                currentPlayer = Player.Human;
                UnlockPlayerControls();
                lblStatus.Text = "Your turn! Play a card or draw.";
            }
        }
        private UnoCard FindValidCard(List<UnoCard> hand)
        {
            return hand.FirstOrDefault(card =>
                card.Value == currentCard.Value ||
                card.Color == currentCard.Color ||
                card.Color == "Wild" ||
                card.Color == wildColor);
        }
        private void PlayCard(UnoCard card, List<UnoCard> hand)
        {
            hand.Remove(card);
            currentCard = card;
            deck.discardPile.Add(card);
        }
        private async Task HandleBotPlayedCard(UnoCard card)
        {
            if (card.Color == "Wild")
            {
                wildColor = ChooseRandomColor();
                lblStatus.Text = $"Bot played a Wild card! Color is now {wildColor}.";
                await Task.Delay(2000);
            }
            else
            {
                wildColor = "Wild";
                lblStatus.Text = $"Bot played {card.Color} {card.Value}.";
            }

            if (card.Value == "Skip" || 
                card.Value == "Reverse" || 
                card.Value == "Draw 2" || 
                card.Value == "Draw 4")
            {
                await HandleEventCard(card);
            }
        }
        private async void BotAction()
        {
            lblStatus.Text = "Bot is thinking...";
            await Task.Delay(1000); // Delay for bot's action

            while (true)
            {
                // Check for a valid card in the bot's hand
                UnoCard validCard = FindValidCard(botHand);
                if (validCard != null)
                {
                    PlayCard(validCard, botHand);
                    await HandleBotPlayedCard(validCard);
                    break;
                }
                else
                {
                    // Draw a card if no valid card exists
                    await DrawCards(1, botHand);
                    lblStatus.Text = "Bot drew a card.";
                    await Task.Delay(500);

                    if (FindValidCard(botHand) != null) continue; // Retry with the new card
                    break;
                }
            }
            await Task.Delay(1000); // Delay before switching back to player
            NextTurn();
        }
        private string ChooseRandomColor()
        {
            string[] colors = { "Red", "Green", "Blue", "Yellow" };
            return colors[new Random().Next(colors.Length)];
        }
        private string ChooseColor()
        {
            string color = "Wild";
            using (ColorForm form = new ColorForm())
            {
                // Open the form as a dialog
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve the selected color
                    color = form.SelectedColor;
                }
            }
            return color;
        }
        private void UpdateUI()
        {
            // Update discard pile
            if (currentCard != null)
            {
                pbDiscardPile.ImageLocation = currentCard.GetImagePath();
            }
            else
            {
                pbDiscardPile.ImageLocation = @"images\back.png";
            }
            // Clear and repopulate player's hand
            flpPlayerHand.Controls.Clear();
            foreach (var card in playerHand)
            {
                var cardPictureBox = new PictureBox
                {
                    Width = 100,
                    Height = 150,
                    ImageLocation = card.GetImagePath(),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = card // Store the card in the Tag property for reference
                };
                cardPictureBox.Click += CardPictureBox_Click; // Attach event handler
                flpPlayerHand.Controls.Add(cardPictureBox);
            }
            // Clear and repopulate bot's hand
            flpBotHand.Controls.Clear();
            foreach (var card in botHand)
            {
                var cardBackPictureBox = new PictureBox
                {
                    Width = 100,
                    Height = 150,
                    ImageLocation = @"images\back.png", // Always show the card back
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = null // No need to store the actual card in the Tag for the bot's hand
                };
                flpBotHand.Controls.Add(cardBackPictureBox);
            }
        }
        private async Task DrawCards(int numberOfCards, List<UnoCard> hand)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                if (deck.RemainingCards == 0)
                {
                    deck.Reshuffle();
                    lblStatus.Text = "Deck reshuffled!";
                    await Task.Delay(1000);
                }
                var card = deck.DrawCard();
                if (card != null) hand.Add(card);
            }
            UpdateUI();
        }
        private void LockPlayerControls()
        {
            pbDrawCard.Enabled = false; // Disable the draw card button
            foreach (Control control in flpPlayerHand.Controls)
            {
                if (control is PictureBox card)
                {
                    card.Enabled = false; // Disable all card PictureBoxes
                }
            }
        }
        private void UnlockPlayerControls()
        {
            pbDrawCard.Enabled = true; // Enable the draw card button
            foreach (Control control in flpPlayerHand.Controls)
            {
                if (control is PictureBox card)
                {
                    card.Enabled = true; // Enable all card PictureBoxes
                }
            }
        }
        private async Task<bool> HandleEventCard(UnoCard card)
        {
            switch (card.Value)
            {
                case "Skip":
                    lblStatus.Text = $"{currentPlayer} played Skip! Next player loses their turn.";
                    await Task.Delay(1000);
                    // Skip the next turn by transitioning back to the same player
                    currentPlayer = (currentPlayer == Player.Human) ? Player.Bot : Player.Human;
                    return true;

                case "Reverse":
                    lblStatus.Text = $"{currentPlayer} played Reverse! Turn order reversed.";
                    await Task.Delay(1000);
                    ReverseTurnOrder();
                    currentPlayer = (currentPlayer == Player.Human) ? Player.Bot : Player.Human;
                    // In a two-player game, Reverse effectively keeps the same player's turn
                    return true;

                case "Draw 2":
                    lblStatus.Text = $"{currentPlayer} played Draw Two! Next player draws 2 cards.";
                    await Task.Delay(1000);
                    if (currentPlayer == Player.Human)
                    {
                        await DrawCards(2, botHand);
                        currentPlayer = Player.Bot;
                    }
                    else
                    {
                        await DrawCards(2, playerHand);
                        currentPlayer = Player.Human;
                    }
                    await Task.Delay(1000);
                    return true;

                case "Draw 4":
                    lblStatus.Text = $"{currentPlayer} played Draw Four! Next player draws 4 cards.";
                    await Task.Delay(1000);
                    if (currentPlayer == Player.Human)
                    {
                        await DrawCards(4, botHand);
                        lblStatus.Text = $"You chose the color {wildColor}.";
                        currentPlayer = Player.Bot;
                    }
                    else
                    {
                        await DrawCards(4, playerHand);
                        lblStatus.Text = $"Bot chose the color {wildColor}.";
                        currentPlayer = Player.Human;
                    }
                    await Task.Delay(1000);
                    return true;
            }
            return false;
        }
        private async void ReverseTurnOrder()
        {
            // Reverse logic can vary depending on how you manage multiple players.
            // For two players, just continue with the current player.
            lblStatus.Text = "Turn order reversed, but there are only two players.";
            await Task.Delay(1000);
        }
        private bool IsCardPlayable(UnoCard card)
        {
            return card.Value == currentCard.Value ||
                   card.Color == currentCard.Color ||
                   card.Color == "Wild" ||
                   card.Color == wildColor;
        }
        private async Task PlayPlayerCard(UnoCard card)
        {
            playerHand.Remove(card);
            currentCard = card;
            deck.discardPile.Add(card);

            if (card.Color == "Wild")
            {
                string chosenColor = ChooseColor();
                wildColor = chosenColor;
                lblStatus.Text = $"You played a Wild card! Color is now {chosenColor}.";
                await Task.Delay(1000);
            }
            else
            {
                wildColor = "Wild"; // Reset wild color after non-wild cards is played
                lblStatus.Text = $"You played {card.Color} {card.Value}.";
                await Task.Delay(1000);
            }

            if (card.Value == "Skip" || card.Value == "Reverse" || card.Value == "Draw 2" || card.Value == "Draw 4")
            {
                await HandleEventCard(card);
            }
            UpdateUI();
            NextTurn();
        }
        private async Task DrawPlayerCard()
        {
            if (deck.RemainingCards == 0)
            {
                deck.Reshuffle();
                lblStatus.Text = "Deck reshuffled!";
                await Task.Delay(1000);
            }
            var newCard = deck.DrawCard();
            if (newCard != null)
            {
                // Show the card player just pulled before add to player hand and update UI
                pbDrawCard.ImageLocation = newCard.GetImagePath();
                await Task.Delay(500);
                pbDrawCard.ImageLocation = @"images\back.png";
                playerHand.Add(newCard);
                UpdateUI();
                lblStatus.Text = "You drew a card.";
                await Task.Delay(1000);
            }
        }
        private async void pbDrawCard_Click(object sender, EventArgs e)
        {
            await DrawPlayerCard();
        }
        private async void CardPictureBox_Click(object sender, EventArgs e)
        {
            var cardPictureBox = sender as PictureBox;
            if (cardPictureBox == null) return;

            var selectedCard = cardPictureBox.Tag as UnoCard;
            if (selectedCard == null) return;

            if (IsCardPlayable(selectedCard))
            {
                await PlayPlayerCard(selectedCard);
            }
            else
            {
                lblStatus.Text = "Invalid card! Play a matching color or value.";
                await Task.Delay(1000);
            }
        }
        private void Game_Resize(object sender, EventArgs e)
        {
            adjustLayout();
        }
    }
}
