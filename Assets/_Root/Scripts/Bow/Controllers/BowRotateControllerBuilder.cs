using Abstractions.Basics;
using Abstractions.Bow;
using Abstractions.Controllers;
using Abstractions.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.Bow
{
    internal sealed class BowRotateControllerBuilder : IBowRotateControllerBuilder
    {
        private IPlayerInfo _playerInfo;
        private IUpdateController _updateController;
        private IUpdateableRemoverFactory _updateableRemoverFactory;

        public BowRotateControllerBuilder(IPlayerInfo playerInfo, IUpdateController updateController, IUpdateableRemoverFactory updateableRemoverFactory)
        {
            _playerInfo = playerInfo;
            _updateController = updateController;
            _updateableRemoverFactory = updateableRemoverFactory;
        }
        public void Build(IBowModel bowModel, IBowView bowView)
        {
            IUpdateDeltaTime bowRotateController = new BowRotateController(bowView, bowModel.BowModelSettings, _playerInfo);
            _updateController.Add(bowRotateController);
            bowView.ActionOnDestroy += _updateableRemoverFactory.Create(bowRotateController).Remove;
        }

    }
}
