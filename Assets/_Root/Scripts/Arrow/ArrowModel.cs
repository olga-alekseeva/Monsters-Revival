using Abstractions.Arrow;

namespace Arrow
{
    internal sealed class ArrowModel : IArrowModel
    {
        private IArrowModelSettings _arrowModelSettings;
        public IArrowModelSettings ArrowModelSettings => _arrowModelSettings;

        private float _shootingForce;


        public float Speed => _arrowModelSettings.Speed;

        public float MoveSpeed => _arrowModelSettings.Speed;

        public float Damage => _shootingForce;

        public ArrowModel(IArrowModelSettings arrowModelSettings)
        {
            _arrowModelSettings = arrowModelSettings;
        }

        public ArrowModel(IArrowModelSettings arrowModelSettings, float shootingForce)
        {
            _arrowModelSettings = arrowModelSettings;
            _shootingForce = shootingForce;
        }
    }
}
