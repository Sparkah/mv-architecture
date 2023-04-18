using GameEngine.Scripts.Money;
using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Tutorial.TutorialSteps
{
    public class TutorialStepUpgradeCookie : TutorialStepController
    {
        [Inject] private MoneySystem _moneySystem;
        [Inject] private TutorialSystem _tutorialSystem;
        private void Awake()
        {
            if (Repository.LoadTutorial(out TutorialStep tutorialStep))
            {
                Debug.Log($"Tutorial {stepType} was already completed");
            }
            else
            {
                _moneySystem.OnMoneyChanged += CheckForMoney;
            }
        }

        private void CheckForMoney(int obj)
        {
            if (_moneySystem.MoneyStorage.Money >= 10)
            {
                ShowTutorial();
                _moneySystem.OnMoneyChanged -= CheckForMoney;
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
            _moneySystem.OnMoneyChanged -= CheckForMoney;
        }
    }
}
