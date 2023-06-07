namespace Abstractions.Arrow
{
    internal interface IArrowModelFactory
    {
        IArrowModel Create();
        public IArrowModel Create(float moveSpeed);
    }
}
