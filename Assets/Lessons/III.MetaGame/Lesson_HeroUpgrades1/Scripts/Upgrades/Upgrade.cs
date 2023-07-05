using System;

namespace Lessons.MetaGame.Upgrades
{
    public abstract class Upgrade
    {
        public string Id
        {
            get { return this.config.id; }
        }

        public int Level
        {
            get { return this.currentLevel; }
            set { this.currentLevel = value; }
        }

        public int MaxLevel
        {
            get { return this.config.maxLevel; }
        }

        public bool IsMaxLevel
        {
            get { return this.currentLevel == this.MaxLevel; }
        }

        private readonly UpgradeConfig config;

        private int currentLevel;

        public Upgrade(UpgradeConfig config)
        {
            this.currentLevel = 1;
            this.config = config;
        }

        public void LevelUp()
        {
            if (this.IsMaxLevel)
            {
                throw new Exception("Max level is reached!");
            }

            this.currentLevel++;
            this.OnUpgrade(this.currentLevel);
        }

        protected abstract void OnUpgrade(int newLevel);
    }
}