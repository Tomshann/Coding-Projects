import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class CardTest {

    @Test
    public void testGetValue() {
        int cardValue = 5;
        Card card = new Card(cardValue);

        assertEquals(cardValue, card.getValue(), "Card value should match");
    }

    // Add more test cases as needed to ensure various functionalities of the Card class
}