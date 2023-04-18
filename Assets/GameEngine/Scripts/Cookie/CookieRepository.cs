using GameEngine.Scripts.Base.SaveLoadGame;
using UnityEngine;

namespace GameEngine.Scripts.Cookie
{
    public class CookieRepository : DataRepository<int>
    {
        protected override string Key => "CookieData";
        public bool LoadCookie(out int maxID)
        {
            if (PlayerPrefs.HasKey(Key))
            {
                maxID = PlayerPrefs.GetInt(Key);

                Debug.Log($"<color=orange>LOAD COOKIE DATA {maxID}</color>");
                return true;
            }

            maxID = default;
            return false;
        }

        public void SaveCookie(int maxID)
        {
            PlayerPrefs.SetInt(Key, maxID);
            Debug.Log($"<color=yellow>SAVE COOKIE DATA {maxID}</color>");
        }
    }
}
