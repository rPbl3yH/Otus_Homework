using System;
using System.Threading.Tasks;

namespace Game.App
{
    public interface ILoadingTask
    {
        void Do(Action<LoadingResult> callback);
    }
}


