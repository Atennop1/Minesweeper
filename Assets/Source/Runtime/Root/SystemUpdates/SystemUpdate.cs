using System;
using System.Collections.Generic;

namespace Minesweeper.Runtime.Root.SystemUpdates
{
    public class SystemUpdate : ISystemUpdate
    {
        private readonly List<IUpdatable> _updatables = new();

        public void UpdateAll() => _updatables.ForEach(updatable => updatable.Update());

        public void AddUpdatable(IUpdatable updatable)
        {
            if (updatable == null)
                throw new ArgumentException("Updatable can't be null");
            
            _updatables.Add(updatable);
        }

        public void RemoveUpdatable(IUpdatable updatable)
        {
            if (!_updatables.Contains(updatable))
                throw new ArgumentException("SystemUpdate doesn't contains this updatable");

            _updatables.Remove(updatable);
        }
    }
}