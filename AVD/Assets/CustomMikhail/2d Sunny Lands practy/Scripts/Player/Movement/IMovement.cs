public interface IMovement 
{
    void setUp();
    void move(float direction);
    void cleanUp();
    void changeMovement(MovementType type);
}
