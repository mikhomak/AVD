using CreatorKitCodeInternal;
using UnityEngine;

namespace Scripts.UI {
    public class MenuUI : MonoBehaviour {
        private void Start() {
            CharacterControl.Instance.m_Agent.speed = 0f;
        }

        public void Play() {
            CharacterControl.Instance.m_Agent.speed = 3.5f;
        }

        public void Credits() {
        }
    }
}