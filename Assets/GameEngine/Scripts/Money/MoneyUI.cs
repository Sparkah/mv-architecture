using TMPro;
using UnityEngine;

namespace GameEngine.Scripts.Money
{
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;

        public void ChangeMoneyText(int money)
        {
            _moneyText.text = money.ToString();
        }
    }
}
