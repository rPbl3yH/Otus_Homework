using System.Collections.Generic;
using SaveLoad.ResourcesObject.Mediator;
using SaveLoad.Units.Mediator;
using Sirenix.OdinInspector;

namespace SaveLoad.GameManagement.Mediators
{
    public class MediatorsInstaller
    {
        [ShowInInspector]
        private List<IGameMediator> _mediators = new List<IGameMediator>();

        public MediatorsInstaller()
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
            _mediators.Add(new ResourcesObjectsMediator());
        }
    }
}