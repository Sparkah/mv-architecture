using UnityEngine;

namespace GameEngine.Helpers
{
    [CreateAssetMenu(
        fileName = "Upgrades",
        menuName = "Helpers"
    )]
    public class HelpersUpgradeSO : ScriptableObject
    {
        [SerializeField] private int[] _helperCost;
        [SerializeField] private int[] _helperIncome;
    }
}