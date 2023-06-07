namespace Abstractions.Arrow
{
    internal interface IArrowInfo
    {
        bool IsPreset { get; }
        IArrowView ArrowView { get; }
        IArrowModel ArrowModel { get; }
        void Destroyed(IArrowModel arrowModel, IArrowView arrowView);
        void Instantiated(IArrowModel arrowModel, IArrowView arrowView);


    }
}
