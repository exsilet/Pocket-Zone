using CodeBase.CameraLogic;
using CodeBase.Hero;
using CodeBase.Hero.Inventory;
using CodeBase.Hero.Weapon;
using CodeBase.Infrastructure.Factory;
using CodeBase.Logic;
using CodeBase.UI.Element;
using CodeBase.UI.Form;
using CodeBase.UI.Service.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadMenuState : IPayloadedState<string>, IState
    {
        private const string InitialPointTag = "InitialPoint";
        private const string HudPath = "Hud/Hud";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;

        private InventorySlot[] _countSlot;
        
        public LoadMenuState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain,
            IGameFactory gameFactory, IUIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _curtain.Hide();

        public void Enter()
        {
        }

        private void OnLoaded()
        {
            InitGameWorld();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag));
            GameObject hudHero = _gameFactory.CreateHud();

            hudHero.GetComponentInChildren<HealthView>().Construct(hero.GetComponent<HeroHealth>());
            hudHero.GetComponentInChildren<AmmoView>().Construct(hero.GetComponent<HeroAttack>());

            InitUiRoot(hero, hudHero);
            CameraFollow(hero);
        }

        private void InitUiRoot(GameObject hero, GameObject hud)
        {
            GameObject uiRoot = _uiFactory.CreateUIRoot();
            
            _countSlot = uiRoot.GetComponentsInChildren<InventorySlot>(true);

            foreach (InventorySlot slot in uiRoot.GetComponentsInChildren<InventorySlot>(true))
            {
                slot.Construct(hero.GetComponent<Inventory>(),
                    uiRoot.GetComponentInChildren<ViewObject>(true));
            }

            uiRoot.GetComponentInChildren<ViewInventory>(true).Construct(hero.GetComponent<Inventory>());

            hero.GetComponent<Inventory>().Construct(uiRoot.GetComponentInChildren<ViewInventory>(true), _countSlot.Length);
        }

        private static void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}