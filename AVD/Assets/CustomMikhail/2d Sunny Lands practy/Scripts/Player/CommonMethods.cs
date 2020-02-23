using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player {
    public class CommonMethods {
        private const int GROUND_LAYER = 1 << 16;

        public static bool onGround(Vector2 position, float distance) {
            Debug.DrawRay(position, Vector3.down * distance, Color.red);
            return Physics2D.Raycast(position, Vector3.down, distance, GROUND_LAYER);
        }


        public static Vector2 createVectorWithoutLoosingXValue(Vector2 vector2, float y) {
            return new Vector2(vector2.x, y);
        }
    }
}