using System.Collections.Generic;
using SaveLoad.Units.Mediator;
using Sirenix.OdinInspector;

namespace SaveLoad.GameManagement.Mediators
{
    public class MediatorInstaller
    {
        [ShowInInspector]
        private List<IGameMediator> _mediators = new List<IGameMediator>();

        public MediatorInstaller()
        {
            GameContext.AddService(this);
        }

        public List<IGameMediator> GetMediators()
        {
            return _mediators;
        }

        public void Install()
        {
            _mediators.Add(new ResourcesMediator());
            _mediators.Add(new UnitsMediator());
        }
    }
}