using System.Collections.Generic;
using GameEngine.Scripts.Cookie;
using GameEngine.Scripts.Cookie.Upgrades;
using GameEngine.Scripts.Helpers;
using GameEngine.Scripts.Money;
using GameEngine.Scripts.Tutorial;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Base.SaveLoadGame
{
    public class DataCollection : MonoBehaviour
    {
        [Inject] private MoneyRepository _moneyRepository;
        [Inject] private CookieRepository _cookieRepository;
        [Inject] private MoneyMediator _moneyMediator;
        [Inject] private CookieMediator _cookieMediator;
        // [Inject] private HelpersRepository _helpersRepository; 
        //change cookie visual
        //reset tutorial
        [Inject] private TutorialSystem _tutorialSystem;
        [Inject] private TutorialRepository _tutorialRepository;
        [Inject] private TutorialStepMediator _tutorialStepMediator;
       
        [SerializeField] private CookieUpgradeSO _cookieUpgrade;

        private List<DataRepository<int>> _data = new List<DataRepository<int>>();

        [Button]
        private void RemoveData()
        {
            _data.Add(_moneyRepository);
            _data.Add(_cookieRepository);
            
            foreach (var dataRepository in _data)
            {
                dataRepository.RemoveData();
            }
            
            _moneyMediator.RemoveData();
            _cookieMediator.RemoveData();
            _cookieUpgrade.CurrentLevel = 0;
            _tutorialRepository.ClearData();
        }
    }
}
