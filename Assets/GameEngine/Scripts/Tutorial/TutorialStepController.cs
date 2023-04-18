using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Tutorial
{
    public abstract class TutorialStepController : MonoBehaviour
    {
        [SerializeField]
        protected TutorialStep stepType;
        
        [SerializeField] protected Transform _pointArrowPosition;

        [Inject]
        private TutorialSystem tutorialManager;
        [Inject] protected TutorialRepository Repository;

        public virtual void ReadyGame()
        {
            this.tutorialManager.OnStepFinished += this.CheckForFinish;
            this.tutorialManager.OnNextStep += this.CheckForStart;
        }
        

        public virtual void FinishGame()
        {
            this.tutorialManager.OnStepFinished -= this.CheckForFinish;
            this.tutorialManager.OnNextStep -= this.CheckForStart;
        }

        protected virtual void OnStart()
        {
        }

        protected virtual void OnStop()
        {
        }

        private void CheckForFinish(TutorialStep step)
        {
            if (this.stepType == step)
            {
                this.OnStop();
            }
        }

        private void CheckForStart(TutorialStep step)
        {
            if (this.stepType == step)
            {
                this.OnStart();
            }
        }
    }
}
