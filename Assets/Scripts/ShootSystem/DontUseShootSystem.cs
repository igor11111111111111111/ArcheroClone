using System;

namespace ArcheroClone
{
    public class DontUseShootSystem : IShootSystem
    {
        public Action OnShoot { get; set; }
    }
}