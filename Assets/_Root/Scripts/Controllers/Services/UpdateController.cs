using Abstractions.Basics;
using Abstractions.Controllers;
using System.Collections.Generic;

namespace Controllers
{
    internal sealed class UpdateController : IUpdateController
    {
        private List<IUpdate> _list;
        private List<IUpdateDeltaTime> _deltaTimeList;

        public UpdateController()
        {
            _list = new List<IUpdate>();
            _deltaTimeList = new List<IUpdateDeltaTime>();
        }

        private void Remove(IUpdate update)
        {
            _list.Remove(update);
        }

        private void Remove(IUpdateDeltaTime updateDeltaTime)
        {
            _deltaTimeList.Remove(updateDeltaTime);
        }

        private void Add(IUpdate update)
        {
            _list.Add(update);
        }

        private void Add(IUpdateDeltaTime updateDeltaTime)
        {
            _deltaTimeList.Add(updateDeltaTime);
        }

        private void UpdateList()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].Update();
            }
        }

        private void UpdateDeltaTimeList(float deltaTime)
        {
            for (int i = 0; i < _deltaTimeList.Count; i++)
            {
                _deltaTimeList[i].Update(deltaTime);
            }
        }

        public void Update(float deltaTime)
        {
            UpdateList();
            UpdateDeltaTimeList(deltaTime);
        }

        public void Add(IUpdateable updateable)
        {
            if (updateable is IUpdate update) Add(update);
            if (updateable is IUpdateDeltaTime updateDeltaTime) Add(updateDeltaTime);
        }

        public void Remove(IUpdateable updateable)
        {
            if (updateable is IUpdate update) Remove(update);
            if (updateable is IUpdateDeltaTime updateDeltaTime) Remove(updateDeltaTime);
        }
    }
}
