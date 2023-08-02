using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace ArcheroClone
{
    public class WinHandler
    {
        public WinHandler(AllUnitsInfo allUnitsInfo, WinGatesTrigger winGatesTrigger)
        {
            Update(allUnitsInfo, winGatesTrigger);
        }

        private async void Update(AllUnitsInfo allUnitsInfo, WinGatesTrigger winGatesTrigger)
        {
            while (true)
            {
                if (allUnitsInfo.List.Count == 1 && 
                    allUnitsInfo.List[0] as PlayerMonobehaviour)
                {
                    winGatesTrigger.Show();
                    return;
                }
                await Task.Delay(1000);
            }
        }
    }
}
