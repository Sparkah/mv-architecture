using GameEngine.Scripts.Base.SaveLoadGame;
using UnityEngine;

namespace GameEngine.Scripts.Tutorial
{
    public class TutorialStepMediator : IGameDataLoader, IGameDataSaver
    {
        public void LoadData()
        {
            Debug.Log("Mediator tutorial load data");
        }

        public void SaveData()
        {
            Debug.Log("Mediator tutorial save data");
        }
    }
}
