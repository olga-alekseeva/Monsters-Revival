namespace Abstractions.Basics
{
    internal interface IUpdateDeltaTime : IUpdateable
    {
        public void Update(float deltaTime);
    }
}
