using GameEngine.Scripts.Base.SaveLoadGame;
using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Money
{
    public class MoneyInstaller : MonoInstaller
    {
        [SerializeField] private MoneySystem _moneySystem;

        public override void InstallBindings()
        {
            Container.Bind<MoneyMediator>().AsTransient();
            Container.Bind<IGameDataLoader>().WithId("Money").To<MoneyMediator>().AsTransient();
            Container.Bind<IGameDataSaver>().WithId("Money").To<MoneyMediator>().AsTransient();
            Container.Bind<MoneyRepository>().AsSingle();

            Container.BindInstance(_moneySystem);
        }
    }
}