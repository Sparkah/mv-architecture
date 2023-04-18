using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameEngine.Scripts.Tutorial
{
    public class TutorialUI : MonoBehaviour
    {
        [Inject] private TutorialSystem _tutorialSystem;

        [SerializeField] private TextMeshProUGUI _tutroialText;
        [SerializeField] private Button _tutorialArrow;

        private void Awake()
        {
            _tutorialSystem.OnNextStep += DisplayArrow;
            _tutorialSystem.OnStepFinished += HideArrow;
            //_tutorialSystem.OnCompleted += Complete;
        }

        private void HideArrow(TutorialStep step)
        {
            _tutorialArrow.onClick.RemoveAllListeners();
            _tutorialArrow.gameObject.SetActive(false);
        }

        private void DisplayArrow(TutorialStep step)
        {
            _tutroialText.text = ShowText(step);
            _tutorialArrow.onClick.AddListener(_tutorialSystem.FinishCurrentStep);
            _tutorialArrow.gameObject.SetActive(true);
        }

        private string ShowText(TutorialStep step)
        {
            return step switch
            {
                TutorialStep.START_TUTORIAL => "Tap on the screen to gain money",
                TutorialStep.UPGRADE_COOKIE => "Tap on the 'Cookie' button to upgrade it",
                _ => "unknown"
            };
        }

        private void OnDestroy()
        {
            _tutorialSystem.OnNextStep -= DisplayArrow;
            _tutorialSystem.OnStepFinished -= HideArrow;
        }
        
        private void Complete()
        {
            Debug.Log("complete");
        }
    }
}
