using Abstractions.Arrow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    internal sealed class ArrowModelFactory : IArrowModelFactory
    {
        private IArrowModelSettings _arrowModelSettings;
        public ArrowModelFactory(IArrowModelSettings arrowModelSettings)
        {
            _arrowModelSettings = arrowModelSettings;
        }
        public IArrowModel Create()
        {
            IArrowModel arrowModel = new ArrowModel(_arrowModelSettings);
            return arrowModel;
        }

        public IArrowModel Create(float shootingForce)
        {
            IArrowModel arrowModel = new ArrowModel(_arrowModelSettings, shootingForce);
            return arrowModel;
        }
    }
}
