using Abstractions.Arrow;
using Abstractions.Basics;
using Abstractions.Bow;
using Abstractions.Controllers;
using Abstractions.Controllers.Archer;
using Abstractions.Controllers.Arrow;
using Abstractions.Controllers.Effects;
using Abstractions.Controllers.Fireball;
using Abstractions.Controllers.InputSystem;
using Abstractions.Effects;
using Abstractions.EnemiesShield;
using Abstractions.Enemy;
using Abstractions.EnemyParent;
using Abstractions.Fireball;
using Abstractions.InputSystem;
using Abstractions.Level;
using Abstractions.Player;
using Abstractions.Portal;
using Abstractions.Shield;
using Abstractions.SimpleEnemy;
using Arrow;
using Bow;
using Controller;
using Controllers;
using Controllers.Archer;
using Controllers.Arrow;
using Controllers.Bow;
using Controllers.Effects;
using Controllers.Fireball;
using Controllers.Patrol;
using Effects;
using EnemiesShield;
using Enemy;
using EnemyParent;
using Fireball;
using InputSystem;
using LaunchCountUI;
using Level;
using MonstersRevival;
using Player;
using Player.Events;
using Portal;
using Settings;
using Shield;
using SimpleEnemy;
using UnityEngine;

namespace Starter
{
    internal sealed class Game
    {
        private IInputModel _inputModel;

        private IUpdateController _updateController;

        private IUpdateableRemoverFactory _updateableRemoverFactory;

        private IEnemiesShieldModelSettings _enemiesShieldModelSettings;

        private IFireballInfo _fireballInfo;
        private IFireballModelFactory _fireballModelFactory;
        private IFireballSettings _fireballSettings;
        private ILaunchingFireballController _launchingFireballController;
        private IDeleteFireballController _deleteFireballController;

        private IEnemyParentInfo _enemyParentInfo;
        private IEnemyModelSettings _enemyModelSettings;
        private IEnemyEventManager _enemyEventManager;
        private IEnemyModelFactory _enemyModelFactory;
        private IEnemyViewFactory _enemyViewFactory;

        private ISimpleEnemyEventManager _simpleEnemyEventManager;
        private ISimpleEnemyViewFactory _simpleEnemyViewFactory;
        private ISimpleEnemyModelFactory _simpleEnemyModelFactory;
        private ISimpleEnemyModelSettings _simpleEnemyModelSettings;

        private IArcherEventManager _archerEventManager;
        private IArcherViewFactory _archerViewFactory;
        private IArcherModelFactory _archerModelFactory;
        private IArcherModelSettings _archerModelSettings;
        private ITargetPatrolFinder _targetPatrolFinder;

        private IArrowEventManager _arrowEventManager;
        private IArrowViewFactory _arrowViewFactory;
        private IArrowModelFactory _arrowModelFactory;
        private IArrowModelSettings _arrowModelSettings;

        private IPlayerInfo _playerInfo;
        private IPlayerModelSettings _playerModelSettings;

        private IPlayerEventOnInstantiate _playerEventOnInstantiate;
        private IPlayerEventOnDestroy _playerEventOnDestroy;

        private IPortalInfo _portalInfo;

        private IHealthBarAttacher _healthBarAttacher;

        private IBowModelSettings _bowModelSettings;
        private IBowEventManager _bowEventManager;

        private IEffectEventManager _effectEventManager;

        public void Start()
        {
            InitData();
            InitControllers();
            InitViews();
        }

        private void InitData()
        {
            InitEffectEventManager();
            InitResourcesSettings();
            InitFireballData();
            InitInputData();
            InitPlayerData();
            InitEnemyData();
            InitArcherSystem();
            InitEnemyParentData();
            InitPortalData();
            InitBowData();
            InitArrowData();
            InitSimpleEnemyData();
        }

        private void InitControllers()
        {
            InitTargetPatrolFinder();
            InitUpdateController();
            InitUpdateableRemoverFactory();
            InitHealthBarAttacher();
            InitInputController();
            InitPlayerControllers();
            InitFireBallControllers();
            InitEnemyController();
            InitArcherControllerBuilders();
            InitEnemyParentZeroController();
            InitPortalControllers();
            InitMainCameraControllers();
            InitBowControllers();
            InitArrowControllers();
            InitEffectControllers();
            InitSimpleEnemyControllers();
            InitLauncheCountUIControllers();
        }

        private void InitViews()
        {
            InitLevelView();
            InitPlayerView();
            InitEnemyViews();
            InitEnemiesShieldViews();
            InitArcherViews();
            InitSimpleEnemyViews();
            InitPortalView();
            InitBowViews();
        }

        private void InitLauncheCountUIControllers()
        {
            ILaunchCountUIInitializer launchCountUIInitializer =
                new LaunchCountUIInitializer(_fireballInfo,
                _launchingFireballController, _updateController);
        }

        private void InitEffectControllers()
        {
            GameObject prefab = Resources.Load<GameObject>(
                ResourcePathes.EffectsPrefabs.SPARK_ROCK);

            IEffectSparkRockStarter effectSparkRockStarter =
                new EffectSparkRockStarter(prefab);

            _effectEventManager.ActionHitEffect +=
                effectSparkRockStarter.StartEffect;
        }

        private void InitEffectEventManager()
        {
            _effectEventManager = new EffectEventManager();
        }

        private void InitTargetPatrolFinder()
        {
            _targetPatrolFinder = new TargetPatrolFinder();
        }

        private void InitHealthBarAttacher()
        {
            GameObject healthBarPrefab = Resources.Load<GameObject>(
                ResourcePathes.Prefabs.HEALTH_BAR);

            IHealthBarControllerBuilder healthBarControllerBuilder =
                new HealthBarControllerBuilder(
                    _updateController, _updateableRemoverFactory);

            _healthBarAttacher = new HealthBarAttacher(
                healthBarPrefab, healthBarControllerBuilder);
        }

        #region PORTAL
        private void InitPortalData()
        {
            _portalInfo = new PortalInfo();
        }

        private void InitPortalControllers()
        {
            IPortalShowController portalShowController =
                new PortalShowController(_portalInfo);
            _enemyParentInfo.AcionOnZeroCount += portalShowController.ShowPortal;
        }
        private void InitPortalView()
        {
            IPortalView portalView = GameObject.FindObjectOfType<PortalView>();
            _portalInfo.Instantiated(portalView);
            portalView.GameObject.SetActive(false);
        }

        #endregion

        #region FIRE_BALL
        private void InitFireBallControllers()
        {
            IFireballMoveReflectionControllerBuilder
                fireballMoveReflectionControllerBuilder =
                new FireballMoveReflectionControllerBuilder(
                    _updateController, _updateableRemoverFactory);

            _fireballInfo.ActionOnInstantiated +=
                fireballMoveReflectionControllerBuilder.Build;

            GameObject fireballPrefab = Resources.Load<GameObject>(
                ResourcePathes.Prefabs.FIREBALL);

            _launchingFireballController = new LaunchingFireballController(
                fireballPrefab, _playerInfo, _fireballInfo, _fireballModelFactory);
            _updateController.Add(_launchingFireballController);

            _deleteFireballController = new DeleteFireballController(_fireballInfo);
            _updateController.Add(_deleteFireballController);

            IFireballDamageApplyControllerBuilder builder =
                new FireballDamageApplyControllerBuilder();
            _fireballInfo.ActionOnInstantiated += builder.Build;

            IFireBallReflectionDamageSetterBuilder
                fireBallReflectionDamageSetterBuilder =
                new FireBallReflectionDamageSetterBuilder(
                    _effectEventManager, _fireballSettings);

            _fireballInfo.ActionOnInstantiated +=
                fireBallReflectionDamageSetterBuilder.Build;

            IFireBallRedirectControllerBuilder
                fireBallRedirectControllerBuilder =
                new FireBallRedirectControllerBuilder(_updateController,
                _updateableRemoverFactory, _playerInfo);

            _fireballInfo.ActionOnInstantiated +=
                fireBallRedirectControllerBuilder.Build;
        }

        private void InitFireballData()
        {
            _fireballSettings = Resources.Load<FireballSettings>(
                ResourcePathes.ScriptableObjects.FIREBALL_SETTINGS);
            _fireballModelFactory = new FireballModelFactory(_fireballSettings);

            _fireballInfo = new FireballInfo(_fireballSettings);
        }
        #endregion


        #region PLAYER
        private void InitMainCameraControllers()
        {
            IMainCameraSettings mainCameraSettings =
                Resources.Load<MainCameraSettings>(
                    ResourcePathes.ScriptableObjects.MAIN_CAMERA_SETTINGS);

            IMainCameraController mainCameraController =
                new MainCameraController(mainCameraSettings, _playerInfo);

            _updateController.Add(mainCameraController);
        }
        private void InitPlayerView()
        {
            IShieldView shieldView = GameObject.FindObjectOfType<ShieldView>();
            IUpdateDeltaTime rotateController = new RotateSpeedController(shieldView, _inputModel.MousePosition, _playerModelSettings);
            _updateController.Add(rotateController);
            shieldView.ActionOnDestroy += _updateableRemoverFactory.Create(rotateController).Remove;

            IPlayerModelFactory playerModelFactory = new PlayerModelFactory(_playerModelSettings);
            IPlayerViewFactory playerViewFactory = new PlayerViewFactory();

            IPlayerView playerView = playerViewFactory.CreateFromScene();
            IPlayerModel playerModel = playerModelFactory.Create();
            _playerEventOnInstantiate.Initiate(playerModel, playerView);
        }

        private void InitPlayerData()
        {
            _playerEventOnInstantiate = new PlayerEventOnInstantiate();
            _playerEventOnDestroy = new PlayerEventOnDestroy();

            _playerInfo = new PlayerInfo();
            _playerEventOnInstantiate.Action += _playerInfo.Instantiated;
            _playerEventOnDestroy.Action += _playerInfo.Destroyed;
        }

        private void InitPlayerControllers()
        {
            IPlayerDestroyControllerBuilder playerDestroyControllerBuilder =
                new PlayerDestroyControllerBuilder(_playerEventOnDestroy);
            _playerEventOnInstantiate.Action += playerDestroyControllerBuilder.Build;

            IPlayerDamageControllerBuilder playerDamageControllerBuilder = new PlayerDamageControllerBuilder();
            _playerEventOnInstantiate.Action += playerDamageControllerBuilder.Build;

            IMovePhysicsControllerBuilder movePhysicsControllerBuilder =
                new MovePhysicsControllerBuilder(_updateController, _updateableRemoverFactory, _inputModel);
            _playerEventOnInstantiate.Action += movePhysicsControllerBuilder.Build;

            IPlayerExitPortalControllerBuilder playerExitPortalControllerBuilder =
                new PlayerExitPortalControllerBuilder();

            _playerEventOnInstantiate.Action += playerExitPortalControllerBuilder.Build;

            _playerEventOnInstantiate.Action += _healthBarAttacher.Attach;
        }
        #endregion PLAYER


        #region INPUT
        private void InitInputData()
        {
            IKeyboardAxis keyboardAxis = new KeyboardAxis();
            IMousePosition mousePosition = new MousePosition();
            _inputModel = new InputModel(keyboardAxis, mousePosition);
        }

        private void InitInputController()
        {
            IKeyBoardController keyBoardController =
                new KeyBoardController(_inputModel);
            IGamePadController gamePadController =
                new GamePadController(_inputModel);
            IUpdate inputController =
                new InputController(keyBoardController, gamePadController);
            _updateController.Add(inputController);
        }
        #endregion INPUT


        #region BOW
        private void InitBowControllers()
        {
            IBowRotateControllerBuilder bowRotateControllerBuilder =
                new BowRotateControllerBuilder(
                    _playerInfo, _updateController, _updateableRemoverFactory);

            _bowEventManager.ActionOnInstantiated += bowRotateControllerBuilder.Build;
        }
        private void InitBowData()
        {
            _bowEventManager = new BowEventManager();
        }

        private void InitBowViews()
        {
            IBowView[] bowViews = GameObject.FindObjectsOfType<BowView>();
            foreach (IBowView bowView in bowViews)
            {
                IBowModel bowModel = new BowModel(_bowModelSettings);
                _bowEventManager.Instantiated(bowModel, bowView);
            }
        }
        #endregion BOW


        #region ENEMY_PARENT
        private void InitEnemyParentZeroController()
        {
            IEnemyParentZeroController enemyParentZeroController =
                new EnemyParentZeroController(_enemyParentInfo);

            _enemyEventManager.ActionOnInstantiated += enemyParentZeroController.OnEnemyInstantiated;
            _enemyEventManager.ActionOnDestroyed += enemyParentZeroController.OnEnemyDestroyed;
            _archerEventManager.ActionOnInstantiated += enemyParentZeroController.OnEnemyInstantiated;
            _archerEventManager.ActionOnDestroyed += enemyParentZeroController.OnEnemyDestroyed;
            _simpleEnemyEventManager.ActionOnInstantiated += enemyParentZeroController.OnEnemyInstantiated;
            _simpleEnemyEventManager.ActionOnDestroyed += enemyParentZeroController.OnEnemyDestroyed;
        }

        private void InitEnemyParentData()
        {
            _enemyParentInfo = new EnemyParentInfo();
        }
        #endregion ENEMY_PARENT


        #region ARROW
        private void InitArrowData()
        {
            IArrowModelSettings arrowModelSettings =
                Resources.Load<ArrowModelSettings>(
                    ResourcePathes.ScriptableObjects.ARROW_MODEL_SETTINGS);

            _arrowEventManager = new ArrowEventManager();
            _arrowModelFactory = new ArrowModelFactory(arrowModelSettings);
            GameObject arrowPrefab = Resources.Load<GameObject>(
                ResourcePathes.Prefabs.ARROW);

            _arrowViewFactory = new ArrowViewFactory(arrowPrefab);
        }

        private void InitArrowControllers()
        {
            IArrowStarter arrowStarter = new ArrowStarter(
                _arrowModelFactory, _arrowViewFactory, _arrowEventManager);

            _arrowEventManager.ActionFireStart += arrowStarter.ArrowStart;

            IArrowMoveControllerBuilder arrowMoveControllerBuilder =
                new ArrowMoveControllerBuilder(_updateController, _updateableRemoverFactory);
            _arrowEventManager.ActionOnInstantiated += arrowMoveControllerBuilder.Build;

            IArrowCollisionControllerBuilder arrowCollisionControllerBuilder =
                new ArrowCollisionControllerBuilder();

            _arrowEventManager.ActionOnInstantiated += arrowCollisionControllerBuilder.Build;
        }

        #endregion ARROW


        #region ARCHER
        private void InitArcherSystem()
        {
            _archerEventManager = new ArcherEventManager();
            _archerModelFactory = new ArcherModelFactory(_archerModelSettings);
            _archerViewFactory = new ArcherViewFactory();
        }

        private void InitArcherControllerBuilders()
        {
            IArcherMoveControllerBuilder archerMoveControllerBuilder =
                new ArcherMoveControllerBuilder(_archerEventManager,
                _archerModelSettings, _playerInfo, _updateController,
                _updateableRemoverFactory, _targetPatrolFinder);

            _archerEventManager.ActionOnInstantiated += archerMoveControllerBuilder.Build;

            IArcherDamageControllerBuilder archerDamageControllerBuilder =
                new ArcherDamageControllerBuilder(_archerEventManager);
            _archerEventManager.ActionOnInstantiated += archerDamageControllerBuilder.Build;

            IArcherAttackControllerBuider archerAttackControllerBuider =
                new ArcherAttackControllerBuider(_playerInfo, _arrowEventManager,
                _updateController, _updateableRemoverFactory);

            _archerEventManager.ActionOnInstantiated += archerAttackControllerBuider.Build;

            _archerEventManager.ActionOnInstantiated += _healthBarAttacher.Attach;
        }

        private void InitArcherViews()
        {
            IArcherView[] archerViews = _archerViewFactory.CreateFromScene();
            foreach (IArcherView archerView in archerViews)
            {
                IArcherModel archerModel = _archerModelFactory.Create();
                _archerEventManager.Instantiated(archerModel, archerView);
            }
        }
        #endregion ARCHER


        #region ENEMY
        private void InitEnemyViews()
        {
            IEnemyView[] enemyViews = _enemyViewFactory.CreateFromScene();
            foreach (IEnemyView enemyView in enemyViews)
            {
                IEnemyModel enemyModel = _enemyModelFactory.Create();
                _enemyEventManager.Instantiated(enemyModel, enemyView);
            }
        }

        private void InitEnemyData()
        {
            _enemyEventManager = new EnemyEventManager();
            _enemyModelFactory = new EnemyModelFactory(_enemyModelSettings);
            _enemyViewFactory = new EnemyViewFactory();
        }

        private void InitEnemyController()
        {
            IEnemyMoveControllerBuilder enemyMoveControllerBuilder =
                new EnemyMoveControllerBuilder(_enemyModelSettings, _playerInfo,
                _updateController, _updateableRemoverFactory, _targetPatrolFinder);

            _enemyEventManager.ActionOnInstantiated +=
                enemyMoveControllerBuilder.Build;

            IEnemyDamageControllerBuilder enemyDamageControllerBuilder =
                new EnemyDamageControllerBuilder(_enemyEventManager);

            _enemyEventManager.ActionOnInstantiated +=
                enemyDamageControllerBuilder.Build;

            IEnemyDamageApplyControllerBuilder enemyDamageApplyControllerBuilder =
                new EnemyDamageApplyControllerBuilder();

            _enemyEventManager.ActionOnInstantiated +=
                enemyDamageApplyControllerBuilder.Build;

            _enemyEventManager.ActionOnInstantiated +=
                _healthBarAttacher.Attach;
        }
        #endregion ENEMY


        #region SIMPLE_ENEMY
        private void InitSimpleEnemyData()
        {
            _simpleEnemyEventManager = new SimpleEnemyEventManager();
            _simpleEnemyModelFactory =
                new SimpleEnemyModelFactory(_simpleEnemyModelSettings);

            _simpleEnemyViewFactory = new SimpleEnemyViewFactory();
        }


        private void InitSimpleEnemyViews()
        {
            ISimpleEnemyView[] simpleEnemyViews =
                _simpleEnemyViewFactory.CreateFromScene();

            foreach (ISimpleEnemyView simpleEnemyView in simpleEnemyViews)
            {
                ISimpleEnemyModel simpleEnemyModel =
                    _simpleEnemyModelFactory.Create();
                _simpleEnemyEventManager.Instantiated(
                    simpleEnemyModel, simpleEnemyView);
            }
        }

        private void InitSimpleEnemyControllers()
        {
            ISimpleEnemyMoveControllerBuilder simpleEnemyMoveControllerBuilder =
                new SimpleEnemyMoveControllerBuilder(_simpleEnemyModelSettings,
                _simpleEnemyEventManager, _playerInfo, _updateableRemoverFactory,
                _targetPatrolFinder, _updateController);

            _simpleEnemyEventManager.ActionOnInstantiated += simpleEnemyMoveControllerBuilder.Build;

            ISimpleEnemyDamageControllerBuilder simpleEnemyDamageControllerBuilder =
                new SimpleEnemyDamageControllerBuilder(_simpleEnemyEventManager);

            _simpleEnemyEventManager.ActionOnInstantiated += simpleEnemyDamageControllerBuilder.Build;
            ISimpleEnemyAttackControllerBuilder simpleEnemyAttackControllerBuilder =
                new SimpleEnemyAttackControllerBuilder();

            _simpleEnemyEventManager.ActionOnInstantiated += _healthBarAttacher.Attach;

        }
        #endregion SIMPLE_ENEMY

        private void InitEnemiesShieldViews()
        {
            IEnemiesShieldView[] enemiesShieldViews =
                GameObject.FindObjectsOfType<EnemiesShieldView>();

            IEnemyShieldViewControllersBuilder enemyShieldViewControllersBuilder =
                new EnemyShieldViewControllersBuilder(_fireballInfo, _playerInfo, _enemiesShieldModelSettings,
                _updateController, _updateableRemoverFactory);

            enemyShieldViewControllersBuilder.Build(enemiesShieldViews);
        }

        private void InitLevelView()
        {
            ILevelList levelList = Resources.Load<LevelList>(
                ResourcePathes.ScriptableObjects.LEVEL_LIST);
            ILevelInstantiator levelInstantiator = new LevelInstantiator(levelList);
            levelInstantiator.InstantiateRandom();
        }
        private void InitResourcesSettings()
        {
            _enemyModelSettings = Resources.Load<EnemyModelSettings>(
                ResourcePathes.ScriptableObjects.ENEMY_MODEL_SETTINGS);

            _enemiesShieldModelSettings =
                Resources.Load<EnemiesShieldModelSettings>(
                    ResourcePathes.ScriptableObjects.ENEMIES_SHIELD_MODEL_SETTINGS);

            _playerModelSettings = Resources.Load<PlayerModelSettings>(
                ResourcePathes.ScriptableObjects.PLAYER_MODEL_SETTINGS);

            _archerModelSettings = Resources.Load<ArcherModelSettings>(
                ResourcePathes.ScriptableObjects.ARCHER_MODEL_SETTINGS);

            _bowModelSettings = Resources.Load<BowModelSettings>(
                ResourcePathes.ScriptableObjects.BOW_MODEL_SETTINGS);

            _simpleEnemyModelSettings = Resources.Load<SimpleEnemyModelSettings>(
                ResourcePathes.ScriptableObjects.SIMPLE_ENEMY_MODEL_SETTINGS);
        }

        private void InitUpdateableRemoverFactory()
        {
            _updateableRemoverFactory =
                new UpdateableRemoverFactory(_updateController);
        }

        private void InitUpdateController()
        {
            _updateController = new UpdateController();
        }
        public void Update(float deltaTine)
        {
            _updateController.Update(deltaTine);
        }
    }
}
