import org.junit.jupiter.api.Test;
import java.util.ArrayList;
import static org.junit.jupiter.api.Assertions.*;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

public class PlayerTest {

    @Test
    public void testPlayerInitialization() {
        int playerIndex = 1;
        Player player = new Player(playerIndex);

        assertNotNull(player, "Player object should not be null");
        assertEquals(playerIndex, player.getNum(), "Player index should match the initialized value");
    }

    @Test
    public void testAddCardToHand() {
        Player player = new Player(1);
        Card card = new Card(5); // Assuming a card with value 5

        player.addCardToHand(card);

        assertEquals(1, player.displayHand().size(), "Player's hand should have one card");
        assertEquals((Integer) 5, player.displayHand().get(0), "Added card should be in the player's hand");
    }

    @Test
    public void testSetLeftAndRightDeck() {
        Player player = new Player(3);
        Deck leftDeck = new Deck(5); // Assuming a deck with initial size 5
        Deck rightDeck = new Deck(3); // Assuming another deck with initial size 3

        player.setLeftDeck(leftDeck);
        player.setRightDeck(rightDeck);

        assertEquals(leftDeck, player.getLeftDeck(), "Left deck should be set correctly");
        assertEquals(rightDeck, player.getRightDeck(), "Right deck should be set correctly");
    }


    @Test
    public void testTakeFromDeckAndRemoveFromHand() throws NoSuchMethodException, InvocationTargetException, IllegalAccessException {
        Player player = new Player(1);
        player.addCardToHand(new Card(1));
        player.addCardToHand(new Card(1));
        player.addCardToHand(new Card(1));
        player.addCardToHand(new Card(1));
        Deck leftDeck = new Deck(1);
        Deck rightDeck = new Deck(2);
        leftDeck.addCard(new Card(1));
        leftDeck.addCard(new Card(2));
        leftDeck.addCard(new Card(3));
        rightDeck.addCard(new Card(1));
        rightDeck.addCard(new Card(2));
        rightDeck.addCard(new Card(3));
        player.setLeftDeck(leftDeck);
        player.setRightDeck(rightDeck);

        Method takeFromDeckMethod = Player.class.getDeclaredMethod("takeFromDeck");
        takeFromDeckMethod.setAccessible(true);
        takeFromDeckMethod.invoke(player);

        // Perform assertions based on the changes expected in takeFromDeck() and removeFromHand()
        assertEquals(4, player.displayHand().size()); // Hand should increase by 1 after takeFromDeck() call

        // Add more assertions to validate specific behaviors
        // For example, check if leftDeck size decreased after takeFromDeck()
        assertEquals(2, player.getLeftDeck().size()); // Assuming takeFromDeck() removed a card from leftDeck
    }
}




