using GameEngine.Scripts.Base.SaveLoadGame;
using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Tutorial
{
    public class TutorialInstaller : MonoInstaller
    {
        [SerializeField] private TutorialSystem _tutorialSystem;
        public override void InstallBindings()
        {
            Container.Bind<TutorialStepMediator>().AsTransient();
            Container.Bind<IGameDataLoader>().WithId("Tutorial").To<TutorialStepMediator>().AsTransient();
            Container.Bind<IGameDataSaver>().WithId("Tutorial").To<TutorialStepMediator>().AsTransient();
            Container.Bind<TutorialRepository>().AsSingle();

            Container.BindInstance(_tutorialSystem);
        }
    }
}
