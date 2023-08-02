using System;

namespace ArcheroClone
{
    public class HealthData
    {
        public int Max;
        public int Current
        {
            get
            {
                return _current;
            }
            set
            {
                _current = value;
                if (_current <= 0)
                    OnDeath?.Invoke();
            }
        }
        private int _current;

        public Action OnDeath;

        public HealthData(int max)
        {
            Max = _current = max;
        }
    }
}