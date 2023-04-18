using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine.Scripts.Tutorial
{
    public class TutorialSystem : MonoBehaviour
    {
        public event Action<TutorialStep> OnStepFinished;

        public event Action<TutorialStep> OnNextStep;

        //public event Action OnCompleted;

        public TutorialStep CurrentStep = TutorialStep.START_TUTORIAL;
        
        [Title("Methods")]
        [GUIColor(0, 1, 0)]
        [Button]
        public void FinishCurrentStep()
        {
            Debug.Log("Tutorial step finished");
            OnStepFinished?.Invoke(CurrentStep);
            CurrentStep += 1;
            Debug.Log("next step is " + CurrentStep);
        }

        [GUIColor(0, 1, 0)]
        [Button]
        public void MoveToNextStep()
        {
            OnNextStep?.Invoke(CurrentStep);
        }
    }
}