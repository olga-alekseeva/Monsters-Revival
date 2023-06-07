using Abstractions.Basics;
using Abstractions.Bow;
using Abstractions.Controllers;
using Abstractions.EnemiesShield;
using Abstractions.Fireball;
using Abstractions.Player;
using Player;

namespace Controllers
{

    internal sealed class BowViewControllersBuilder : IBowViewControllersBuilder
    {
        private IPlayerInfo _playerInfo;
        private IBowModelSettings _bowModelSettings;
        private IUpdateController _updateController;
        private IUpdateableRemoverFactory _updateableRemoverFactory;

        public BowViewControllersBuilder(IPlayerInfo playerInfo, IBowModelSettings bowModelSettings,
            IUpdateController updateController, IUpdateableRemoverFactory updateableRemoverFactory)
        {
            _playerInfo = playerInfo;
            _bowModelSettings = bowModelSettings;
            _updateController = updateController;
            _updateableRemoverFactory = updateableRemoverFactory;
        }

        public void Build(IBowView bowView)
        {
           
        }

        public void Build(IBowView[] bowViews)
        {
            foreach(IBowView archerView in bowViews)
            {
                Build(archerView);
            }
        }
    }
}
