using UnityEngine;

namespace GameEngine.Scripts.Cookie.Upgrades
{
    [CreateAssetMenu(
        fileName = "Upgrades",
        menuName = "Cookies"
    )]
    public class CookieUpgradeSO : ScriptableObject
    {
        public int CurrentLevel;
        public int[] CostProgression => _costProgression;
        public int[] AdditionalIncome => _additionalIncome; 
        public Transform[] Slices => _slices;
        
        [SerializeField] private int[] _costProgression;
        [SerializeField] private int[] _additionalIncome;
        [SerializeField] private Transform[] _slices;
    }
}
