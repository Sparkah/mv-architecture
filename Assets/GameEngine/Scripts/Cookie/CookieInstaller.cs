using GameEngine.Scripts.Base.SaveLoadGame;
using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Cookie
{
    public class CookieInstaller : MonoInstaller
    {
        [SerializeField] private CookieSystem _cookieSystem;
        public override void InstallBindings()
        {
            Container.Bind<CookieMediator>().AsTransient();
            Container.Bind<IGameDataLoader>().WithId("Cookie").To<CookieMediator>().AsTransient();
            Container.Bind<IGameDataSaver>().WithId("Cookie").To<CookieMediator>().AsTransient();
            Container.Bind<CookieRepository>().AsSingle();

            Container.BindInstance(_cookieSystem);
        }
    }
}