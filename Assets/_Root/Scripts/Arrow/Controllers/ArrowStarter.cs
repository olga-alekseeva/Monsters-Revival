using Abstractions.Arrow;
using Abstractions.Controllers.Arrow;
using UnityEngine;

namespace Controllers.Arrow
{
    internal sealed class ArrowStarter : IArrowStarter
    {
        private IArrowModelFactory _arrowModelFactory;
        private IArrowViewFactory _arrowViewFactory;
        private IArrowEventManager _arrowEventManager;

        public ArrowStarter(IArrowModelFactory arrowModelFactory, IArrowViewFactory arrowViewFactory, IArrowEventManager arrowEventManager)
        {
            _arrowModelFactory = arrowModelFactory;
            _arrowViewFactory = arrowViewFactory;
            _arrowEventManager = arrowEventManager;
        }

        public void ArrowStart(Vector3 position, Quaternion rotation, float shootingForce)
        {
            IArrowModel model = _arrowModelFactory.Create(shootingForce);
            IArrowView view = _arrowViewFactory.Create(position, rotation);
            _arrowEventManager.Instantiated(model, view);
        }
    }
}
