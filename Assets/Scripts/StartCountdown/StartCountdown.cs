using System.Threading.Tasks;
using Zenject;

namespace ArcheroClone
{
    public class StartCountdown
    {
        private StartCountdownUI _ui;
        private int _currentTime;

        public StartCountdown(StartCountdownUI ui)
        {
            _ui = ui;
            _currentTime = 3;
        }

        public async Task Countdown()
        {
            _ui.Refresh(_currentTime);
            while (_currentTime != 0)
            {
                await Task.Delay(1000);
                _currentTime--;
                _ui.Refresh(_currentTime);
            }
        }
    }
}
