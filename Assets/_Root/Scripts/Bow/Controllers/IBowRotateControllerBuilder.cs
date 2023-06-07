namespace Abstractions.Bow
{
    internal interface IBowRotateControllerBuilder
    {
        void Build(IBowModel bowModel, IBowView bowView);
    }
}