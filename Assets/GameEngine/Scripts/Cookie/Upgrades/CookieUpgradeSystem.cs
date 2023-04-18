using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine.Scripts.Cookie.Upgrades
{
    public class CookieUpgradeSystem : MonoBehaviour
    {
        [SerializeField] private CookieUpgradeSO _cookieUpgrade;

        public CookieUpgradeSO CookieUpgrade => _cookieUpgrade;
        
        [Button]
        public void Upgrade()
        {
            Debug.Log("Cookie upgraded");
            if (_cookieUpgrade.CurrentLevel < _cookieUpgrade.CostProgression.Length - 1)
            {
                _cookieUpgrade.CurrentLevel += 1;
            }
            else
            {
                Debug.Log("cookie is max level " + _cookieUpgrade.CurrentLevel);
                _cookieUpgrade.CurrentLevel += 0;
            }
        }
    }
}
