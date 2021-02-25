using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitDemo
{
    public abstract class Enemy
    {
        public string Name { get; set; }
        public abstract double TotalSpecialPower { get; }
        public abstract double SpecialPowerUses { get; }
        public double SpecialAttackPower => TotalSpecialPower / SpecialPowerUses;

    }
}
