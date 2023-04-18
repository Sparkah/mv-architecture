using GameEngine.Scripts.Base.SaveLoadGame;
using Zenject;

namespace GameEngine.Scripts.Money
{
    public sealed class MoneyMediator : IGameDataLoader, IGameDataSaver
    {
        [Inject] private MoneyRepository _repository;
        [Inject] private MoneySystem _system;

        void IGameDataLoader.LoadData()
        {
            if (!_repository.LoadMoney(out var money)) return;
            var moneyStorage = _system.MoneyStorage;
            moneyStorage.SetupMoney(money);
            moneyStorage.AddMoney(0);
        }

        void IGameDataSaver.SaveData()
        {
            var moneyStorage = _system.MoneyStorage;
            _repository.SaveMoney(moneyStorage.Money);
        }

        public void RemoveData()
        {
            var moneyStorage = _system.MoneyStorage;
            moneyStorage.SetupMoney(0);
            moneyStorage.AddMoney(0);
        }
    }
}