import java.io.FileWriter;
import java.util.List;
import java.util.ArrayList;
import java.io.IOException;

public class Deck {
    private int deckNumber;
    private List<Card> cards;

    public Deck(int i) { //assigns the deck number and list of cards
        this.deckNumber = i;
        this.cards = new ArrayList<>();
    }

    public int size() {
        return cards.size();
    } //returns the size of the deck

    public void addCard(Card card) {
        cards.add(card);
    } //adds a card to the deck

    public void removeCard(Card card) {
        cards.remove(card);
    } //removes a card from the deck

    public void clearCards(){
        this.cards.clear();
    } //clears all cards from the deck

    public List<Card> getCards() {
        return cards;
    } // returns the list of cards in the deck

    public Card getTopCard() {
        return cards.get(0); //gets the card at the top of the deck
    }

    public void addToBottom(Card cardToBeRemoved) {
        this.cards.add(0, cardToBeRemoved); //adds a card to the deck
    }

    public String getNum() {
        return Integer.toString(this.deckNumber); //gets the deck number
    }

    public void writeToFile(String fileName) { //outputs the deck contents to a file
        try (FileWriter writer = new FileWriter(fileName)) {
            for (Card card : cards) {
                writer.write(card.getValue() + "\n");
            }

        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}
