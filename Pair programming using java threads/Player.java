import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;
import java.io.FileWriter;

public class Player implements Runnable {
    private int playerNumber;
    private List<Card> hand;
    private Deck leftDeck;
    private Deck rightDeck;

    private static final Object lock = new Object();

    private static boolean winnerFound = false;
    private static volatile int winningPlayer = -1;

    private File outfile;



    public Player(int i){
        //intialise playernumber and hand
        this.playerNumber = i;
        this.hand = new ArrayList<>();
        outfile = new File("player" + (playerNumber + 1) + "_output.txt"); //set the filename/path
    }


    /**
     * Executes the thread to start playing the game
     */
    @Override
    public void run() {
        //write the initial hand to file
        try {
            FileWriter writer = new FileWriter(outfile);
            writer.append("player" + (playerNumber + 1) + " initial hand " + hand.get(0).getValue() + " " + hand.get(1).getValue() + " " + hand.get(2).getValue() + " " + hand.get(3).getValue() + "\n");
            writer.close();
        } catch (IOException e) {
            System.out.println("invalid file");
        }


        while (!checkwin()) {
            synchronized (lock) {
                takeFromDeck(); // This method will end up calling the discard function also as the two actions should be treated as one atomic action
                if (checkwin() && winningPlayer == -1) { //if a player has won after drawing a card
                    System.out.println("Player " + (playerNumber + 1) + " has won!"); //write to console they have won
                    //assign winning player and notify all threads
                    winningPlayer = playerNumber;
                    winnerFound = true;
                    lock.notifyAll();
                    if (winningPlayer == this.playerNumber) { //write the winners textfile
                        try {
                            FileWriter writer = new FileWriter(outfile, true);
                            writer.append("Player " + (this.playerNumber + 1) + " wins" + "\n");
                            writer.append("Player " + (this.playerNumber + 1) + " exits" + "\n");
                            writer.append("Player " + (this.playerNumber + 1) + " hand " + hand.get(0).getValue() + " " + hand.get(1).getValue() + " " + hand.get(2).getValue() + " " + hand.get(3).getValue() + "\n");
                            writer.close();
                        } catch (IOException e) {
                            System.out.println("invalid file");
                        }
                    }

                }
            }
            synchronized (lock) { //write all other players textfile
                if (winnerFound && this.playerNumber != winningPlayer) {
                    // A winner has been found, stop the thread
                    try {
                        FileWriter writer = new FileWriter(outfile, true);
                        writer.append("Player " + (winningPlayer+1) + " has informed player" + (this.playerNumber + 1) + " that player" + (winningPlayer+1) + " has won" + "\n");
                        writer.append("Player " + (this.playerNumber + 1) + " exits" + "\n");
                        writer.append("Player " + (this.playerNumber + 1) + " hand " + hand.get(0).getValue() + " " + hand.get(1).getValue() + " " + hand.get(2).getValue() + " " + hand.get(3).getValue() + "\n");
                        writer.close();
                    } catch (IOException e) {
                        System.out.println("invalid file");
                    }
                    return;
                }
            }

        }
        //handling the instant win outcome
        synchronized (lock) {
            lock.notifyAll(); //notifying all threads a winner has been found
            if (winningPlayer == -1) {
                winningPlayer = playerNumber;
                winnerFound = true;
                if (winnerFound && this.playerNumber == winningPlayer) { //output the winner
                    System.out.println("Player " + (playerNumber + 1) + " has won!");
                }
                if (winningPlayer == this.playerNumber) { //write the winners file
                    try {
                        FileWriter writer = new FileWriter(outfile, true);
                        writer.append("Player " + (this.playerNumber + 1) + " wins" + "\n");
                        writer.append("Player " + (this.playerNumber + 1) + " exits" + "\n");
                        writer.append("Player " + (this.playerNumber + 1) + " hand " + hand.get(0).getValue() + " " + hand.get(1).getValue() + " " + hand.get(2).getValue() + " " + hand.get(3).getValue() + "\n");
                        writer.close();
                    } catch (IOException e) {
                        System.out.println("invalid file");
                    }
                }
            }
            if (winnerFound && this.playerNumber != winningPlayer) { //write all other players files
                // A winner has been found, stop the thread
                try {
                    FileWriter writer = new FileWriter(outfile, true);
                    writer.append("Player " + (winningPlayer+1) + " has informed player" + (this.playerNumber + 1) + " that player" + (winningPlayer+1) + " has won" + "\n");
                    writer.append("Player " + (this.playerNumber + 1) + " exits" + "\n");
                    writer.append("Player " + (this.playerNumber + 1) + " hand " + hand.get(0).getValue() + " " + hand.get(1).getValue() + " " + hand.get(2).getValue() + " " + hand.get(3).getValue() + "\n");
                    writer.close();
                } catch (IOException e) {
                    System.out.println("invalid file");
                }

            }
        }







    }

    /**
     *      This function assigns the deck that is to the left of the player.
     *      @param deck
     *      deck is he paramater that is passed into the function to represent the deck to the left of the player
     */
    public void setLeftDeck(Deck deck){
        this.leftDeck = deck;
    }

    /**
     *      This function assigns the deck that is to the right of the player.
     *      @param deck
     *      deck is he paramater that is passed into the function to represent the deck to the right of the player
     */
    public void setRightDeck(Deck deck){
        this.rightDeck = deck;
    }

    /**
     * This function is synchronized with the removeFromHand() function so that there is no issue with cards being added and removed at the same tinme,
     * the function takes the top card from the deck to the left.
     *
     */
    private synchronized void takeFromDeck() {
            if (leftDeck.size() > 0) { //checks to make sure the deck isnt empty
                removeFromHand();
                Card drawnCard = leftDeck.getTopCard(); //assign the drawn card
                leftDeck.removeCard(drawnCard);
                hand.add(drawnCard); //add the card to hand
                outfile = new File("player" + (playerNumber + 1) + "_output.txt"); //write the action to the player file
                try {
                    FileWriter writer = new FileWriter(outfile, true);
                    writer.append("player " + (playerNumber + 1) + " draws a " + drawnCard.getValue() + " from deck " + leftDeck.getNum() + "\n");
                    writer.append("player " + (playerNumber + 1) + " current hand is " + hand.get(0).getValue() + " " + hand.get(1).getValue() + " " + hand.get(2).getValue() + " " + hand.get(3).getValue() + "\n");
                    writer.close();
                } catch (IOException e) {
                    System.out.println("invalid file");
                }

            }
    }

    /**
     * This function identifies a card that doesn't match the player bias and selects it to be removed from the deck.
     */
    private synchronized void removeFromHand () {
        Card cardToBeRemoved = null;
        for (Card card : hand) { //iterates over the hand to see if there is a card that is needed to be removed
            if (card.getValue() != playerNumber+1) {
                cardToBeRemoved = card; //identifies the card to be removed
                break;  // Stop the iteration early.
            }
        }
        if (cardToBeRemoved!= null) { //ensures the card inst null
            rightDeck.addToBottom(cardToBeRemoved); //adds the card to the bottom of the right deck
            try { //write the action to the player file
                FileWriter writer = new FileWriter(outfile, true);
                writer.append("player " + (playerNumber + 1) + " discards a " + cardToBeRemoved.getValue() + " from deck " + rightDeck.getNum() + "\n");
                writer.close();
            } catch (IOException e) {
                System.out.println("invalid file");
            }
            hand.remove(cardToBeRemoved); //remove the card from the players hand

            try {
                FileWriter writer = new FileWriter(outfile, true); //output the players current hand
                writer.append("player " + (playerNumber + 1) + "  hand is " + hand.get(0).getValue() + " " + hand.get(1).getValue() + " " + hand.get(2).getValue() + "\n");
                writer.close();
            } catch (IOException e) {
                System.out.println("invalid file");
            }
        }

    }




    /**
     * This function returns the values of the cards currently held by the player
     * @return  cardvals
     * returns the list of card values
     */
    public ArrayList<Integer> displayHand(){
        ArrayList<Integer> cardvals = new ArrayList<Integer>();
        for(Card c : hand) {
            cardvals.add(c.getValue());
        }

        return cardvals;
    }

    /**
     * This function checks to see if all values of card held by the player of the same
     * @return  boolean
     * if the card values are the same then return true, otherwise false.
     */
    private boolean checkwin(){
        if(hand.get(0).getValue() == hand.get(1).getValue() && hand.get(1).getValue() == hand.get(2).getValue() && hand.get(2).getValue() == hand.get(3).getValue()) {
            return true;
        }
        else {
            return false;
        }
    }

    public void addCardToHand(Card card){
        this.hand.add(card); //adds a card to the players hand
    }

    public int getNum() {
        return this.playerNumber; //gets the playerNumber
    }


    public Deck getLeftDeck() {
        return this.leftDeck; //gets the leftDeck
    }

    public Deck getRightDeck() {
        return this.rightDeck;  //gets the right deck
    }
}