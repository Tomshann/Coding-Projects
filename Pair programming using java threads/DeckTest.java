import org.junit.jupiter.api.Test;
import java.io.*;
import java.util.List;
import static org.junit.jupiter.api.Assertions.*;

public class DeckTest {

    @Test
    public void testSize() {
        Deck deck = new Deck(1);
        assertEquals(0, deck.size(), "Deck size should be 0 initially");

        Card test_card = new Card(5);

        deck.addCard(test_card);
        assertEquals(1, deck.size(), "Deck size should be 1 after adding a card");

        deck.removeCard(test_card);
        assertEquals(0, deck.size(), "Deck size should be 0 after removing the card");

        deck.addCard(test_card);
        assertEquals(1, deck.size(), "Deck size should be 1 after adding a card");

        deck.clearCards();
        assertEquals(0, deck.size(), "Deck size should be 0 after removing the card");
    }

    @Test
    public void testGetTopCard() {
        Deck deck = new Deck(1);
        Card card = new Card(8);
        deck.addCard(card);

        assertEquals(card, deck.getTopCard(), "Top card should match the added card");
    }

    @Test
    public void testAddToBottom() {
        Deck deck = new Deck(1);
        Card card = new Card(3);
        deck.addCard(new Card(7));
        deck.addToBottom(card);

        assertEquals(card, deck.getTopCard(), "Added card should be at the bottom of the deck");
    }

    @Test
    public void testWriteToFile() throws IOException {
        Deck deck = new Deck(1);
        deck.addCard(new Card(2));
        deck.addCard(new Card(4));

        String fileName = "test_deck_write.txt";
        deck.writeToFile(fileName);

        // Read the content from the file and check if it matches the deck's cards
        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            List<Card> cards = deck.getCards();
            String line;
            int index = 0;
            while ((line = reader.readLine()) != null) {
                assertEquals(Integer.parseInt(line), cards.get(index).getValue(),
                        "Card values should match the content written to the file");
                index++;
            }
        }

        // Clean up the created file after the test
        File file = new File(fileName);
        if (!file.delete()) {
            System.out.println("Failed to delete the file");
        }
    }
}
