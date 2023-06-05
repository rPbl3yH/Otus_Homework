using System;

namespace ShootEmUp
{
	public sealed partial class LevelBackground
	{
		[Serializable]
        public sealed class LevelConfigs
        {
            public float StartPositionY;
            public float EndPositionY;
            public float MovingSpeedY;
        }
    }
}