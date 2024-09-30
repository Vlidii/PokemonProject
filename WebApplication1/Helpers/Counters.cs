using System.Reflection;

namespace WebApplication1.Helpers
{
    public class Counters
    {
        public int CountHP(int baseHP, int iv, int ev, int level)
        {
            var HP = ((2 * baseHP + iv + (ev / 4) * level) / 100) + level + 10;
            return HP;
        }
        public int CountStat(int baseStat, int iv, int ev, int level)
        {
            var stat = (int)((((2*baseStat+iv+(ev/4)*level)/100)+5));
            return stat;
        }
        public bool CheckEV(int hpEV,int attackEV,int defenseEV,int spAttackEV,int spDefenseEV, int speedEV)
        {
            var totalEV = hpEV+attackEV+defenseEV+spAttackEV+spDefenseEV+speedEV;
            if (totalEV > 510) 
            {
                return false;
            }
            return true;
        }
    }
}
