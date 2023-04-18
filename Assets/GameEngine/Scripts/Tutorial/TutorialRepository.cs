using System;
using GameEngine.Scripts.Base.SaveLoadGame;
using UnityEngine;

namespace GameEngine.Scripts.Tutorial
{
    public class TutorialRepository : DataRepository<TutorialStep>
    {
        protected override string Key => "TutorialData";
        public bool LoadTutorial(out TutorialStep name)
        {
            TutorialStep en;
            if (PlayerPrefs.HasKey(Key))
            {
                Enum.TryParse(PlayerPrefs.GetString(Key), out en);
                name = en;
                Debug.Log($"<color=orange>LOAD TUTORIAL DATA {name}</color>");
                return true;
            }
            
            name = default;
            return false;
        }

        public void SaveTutorial(string name)
        {
            PlayerPrefs.SetString(Key, name);
            Debug.Log($"<color=yellow>SAVE TUTORIAL DATA {name}</color>");
        }

        public void ClearData()
        {
            foreach (TutorialStep enumValue in Enum.GetValues(typeof(TutorialStep)))
            {
                PlayerPrefs.DeleteKey(enumValue.ToString());
            }
            PlayerPrefs.DeleteKey(Key);
        }
    }
}
