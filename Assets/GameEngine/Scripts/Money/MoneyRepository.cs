using GameEngine.Scripts.Base.SaveLoadGame;
using UnityEngine;

namespace GameEngine.Scripts.Money
{
    public class MoneyRepository : DataRepository<int>
    {
        protected override string Key => "MoneyData";
        public bool LoadMoney(out int amount)
        {
            if (PlayerPrefs.HasKey(Key))
            {
                amount = PlayerPrefs.GetInt(Key);

                Debug.Log($"<color=orange>LOAD MONEY DATA {amount}</color>");
                return true;
            }

            amount = default;
            return false;
        }

        public void SaveMoney(int amount)
        {
            PlayerPrefs.SetInt(Key, amount);

            Debug.Log($"<color=yellow>SAVE MONEY DATA {amount}</color>");
        }
        
        public override void RemoveData()
        {
            PlayerPrefs.DeleteKey(Key);
            LoadMoney(out int amount);
        }
    }
}