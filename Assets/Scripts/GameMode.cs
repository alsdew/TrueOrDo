public class GameMode 
{
    public static int START = 0;
    public static int TO_MALE = 1;
    public static int MALE = 2;
    public static int TO_FEMALE = 3;
    public static int FEMALE = 4;
    public static int MIN_VALUE = 1;
    public static int MAX_VALUE = 4;
    
    private int value = START;

    public GameMode() {
        value = START;
    }

    public int current {
        get {
            return value;
        }
    }

    public void next() {
        value += 1;
        if (value > MAX_VALUE) {
            value = MIN_VALUE;
        }
    }

    public bool check(int arg) {
        return (arg == value);
    }

    public bool isChange {
        get {
            return value == TO_MALE || value == TO_FEMALE;
        }
    }
    public bool isMale {
        get {
            return value == TO_MALE || value == MALE;
        }
    }
}
