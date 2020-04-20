using CreatorKitCodeInternal;
using UnityEngine;

namespace Scripts.UI {
    public class MenuUI : MonoBehaviour {
        [SerializeField] private GameObject mainPage;
        [SerializeField] private GameObject creditPage;
        [SerializeField] private GameObject intro;
        [SerializeField] private GameObject mainImage;

        public void Play() {
            mainPage.SetActive(false);
            mainImage.SetActive(false);
            intro.SetActive(true);
        }

        public void GoToCreditsPage() {
            creditPage.SetActive(true);
            mainPage.SetActive(false);
        }

        public void GoToMainPage() {
            creditPage.SetActive(false);
            mainPage.SetActive(true);
        }
    }
}