import java.util.Scanner;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class CardGame {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Read the number of players from the command line
        int numberOfPlayers = 0;
        boolean validInput = false;

        while (!validInput) {
            System.out.print("Enter the number of players: ");
            try {
                numberOfPlayers = Integer.parseInt(scanner.nextLine());
                if (numberOfPlayers > 0) {
                    validInput = true;
                } else {
                    System.out.println("Please enter a positive integer for the number of players.");
                }
            } catch (NumberFormatException e) {
                System.out.println("Invalid input. Please enter a valid number of players.");
            }
        }

        Deck pack = new Deck(8 * numberOfPlayers);

        // Read the name of the input pack file (without path) from the command line
        String packFileName = null;
        boolean validPackFile = false;

        // Continue to prompt for the file name until a valid file is provided
        while (!validPackFile) {
            System.out.print("Please enter the name of the pack file (without path): ");
            packFileName = scanner.nextLine();

            try (BufferedReader reader = new BufferedReader(new FileReader(packFileName))) {
                String line;
                // Inside the try block for reading the pack file
                while ((line = reader.readLine()) != null) {
                    int cardValue = Integer.parseInt(line);
                    Card card = new Card(cardValue);
                    pack.addCard(card); // Assuming you have a method to add cards to the deck
                }

                if (pack.size() != (8 * numberOfPlayers)) {
                    System.out.println("Error: The pack does not have the expected number of cards.");
                     pack.clearCards();
                } else {
                    validPackFile = true; // Valid file, exit the loop
                }
            } catch (IOException e) {
                System.out.println("Invalid file. Please provide a valid pack file.");
            }
        }


        Deck[] decks = new Deck[numberOfPlayers]; // Create an array of decks
        Player[] players = new Player[numberOfPlayers]; // Create an array of players


        for (int i = 0; i < numberOfPlayers; i++) {
            decks[i] = new Deck(numberOfPlayers); // Initialize each deck with the appropriate length
            players[i] = new Player(i); // Initialize each player with their index and decks
        }


        //distribute cards

        // Distribute four cards to each player from the top of the pack in a round-robin fashion

        int cardsPerPlayer = 4;

        for (int i = 0; i < cardsPerPlayer; i++) {
            for (int playerIndex = 0; playerIndex < numberOfPlayers; playerIndex++) {
                Card card = pack.getTopCard(); // Remove the top card from the pack
                pack.removeCard(card);
                players[playerIndex].addCardToHand(card); // Add the card to the player's hand
            }
        }

// Fill the decks from the remaining cards in the pack in a round-robin fashion
        while (!pack.getCards().isEmpty()) {
            for (int playerIndex = 0; playerIndex < numberOfPlayers; playerIndex++) {
                if (!pack.getCards().isEmpty()) {
                    Card card = pack.getTopCard(); // Remove the top card from the pack
                    pack.removeCard(card);
                    decks[playerIndex].addCard(card); // Add the card to the player's deck
                }
            }
        }


        for (Player player : players) {

            Deck leftDeck;
            Deck rightDeck;

            if (player.getNum() == (numberOfPlayers-1)){ //initialise the last players deck
                leftDeck = decks[numberOfPlayers-1];
                rightDeck = decks[0];
            }
            else{ //initialise all the other players decks
                leftDeck = decks[player.getNum()];
                rightDeck = decks[player.getNum()+1];
            }
            player.setLeftDeck(leftDeck);  //set the decks
            player.setRightDeck(rightDeck);
            new Thread(player).start(); //start the threads



            //THREADS FINISHED
            for (int i = 0; i < numberOfPlayers; i++) {
                String fileName = "deck" + (i+1) + "_output.txt";  // Customize the file name as needed
                decks[i].writeToFile(fileName); //call the method to write the deck contents to a file
            }

        }
    }
}