using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine.Scripts.Money
{
    public sealed class MoneyStorage : MonoBehaviour
    {
        public event Action<int> OnMoneyChanged;

        public int Money
        {
            get { return money; }
        }

        [ReadOnly]
        [ShowInInspector]
        private int money;

        [Button]
        public void SetupMoney(int money)
        {
            this.money = money;
            //AddMoney(0);
        }

        [Button]
        public void AddMoney(int range)
        {
            money += range;
            OnMoneyChanged?.Invoke(money);
        }

        [Button]
        public void SpendMoney(int range)
        {
            money -= range;
            OnMoneyChanged?.Invoke(money);
        }
    }
}
