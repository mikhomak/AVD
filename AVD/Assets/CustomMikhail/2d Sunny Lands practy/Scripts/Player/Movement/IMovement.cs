namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Movement {
    public interface IMovement 
    {
        void setUp();
        void move(float direction);
        void cleanUp();
        void changeMovement(MovementType type);
    }
}
