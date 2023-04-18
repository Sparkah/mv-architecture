using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Tutorial.TutorialSteps
{
    public class TutorialStepWelcome : TutorialStepController
    {
        [Inject] private TutorialSystem _tutorialSystem;
        
        private void Start()
        {
            _tutorialSystem.OnStepFinished += SaveTutorial;
            if (Repository.LoadTutorial(out TutorialStep tutorialStep))
            {
                Debug.Log($"Tutorial {stepType} was already completed");
            }
            else
            {
                ShowTutorial();
            }
        }

        private void ShowTutorial()
        {
            _tutorialSystem.MoveToNextStep();
        }

        private void SaveTutorial(TutorialStep step)
        {
            Repository.SaveTutorial(step.ToString());
        }

        private void OnDestroy()
        {
            _tutorialSystem.OnStepFinished -= SaveTutorial;
        }
    }
}