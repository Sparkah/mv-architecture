using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Input
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private InputSystem _inputSystem;

        public override void InstallBindings()
        {
            Container.Bind<InputSystem>().FromInstance(_inputSystem).AsSingle();
        }
    }
}
