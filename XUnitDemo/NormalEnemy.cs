using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitDemo
{
    public class NormalEnemy : Enemy
    {
        public override double TotalSpecialPower => 100;

        public override double SpecialPowerUses => 2;
    }
}
