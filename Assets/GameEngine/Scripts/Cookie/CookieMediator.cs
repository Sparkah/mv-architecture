using GameEngine.Scripts.Base.SaveLoadGame;
using Zenject;

namespace GameEngine.Scripts.Cookie
{
    public class CookieMediator : IGameDataLoader, IGameDataSaver
    {
        [Inject] private CookieRepository _repository;
        [Inject] private CookieSystem _system;

        void IGameDataLoader.LoadData()
        {
            _system.CookieUpgradeSystem.CookieUpgrade.CurrentLevel = _repository.LoadCookie(out var maxID) ? maxID : 0;
        }

        void IGameDataSaver.SaveData()
        {
            var maxCookieID = _system.CookieUpgradeSystem;
            _repository.SaveCookie(maxCookieID.CookieUpgrade.CurrentLevel);
        }

        public void RemoveData()
        {
            _repository.SaveCookie(0);
        }
    }
}
