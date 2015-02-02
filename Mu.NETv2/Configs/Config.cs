using Mu.NETv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mu.NETv2.Configs
{
    public class Config
    {
        public const int RESET_COST = 1000000;
        public const bool DYNAMIC_COST = false;
        public const int RESET_LEVEL = 400;
        static public bool isResetable(Character character){
            if (character.cLevel >= 400)
            {
                if (DYNAMIC_COST && character.Money >= RESET_COST * (character.Resets+1)) return true;
                else if (!DYNAMIC_COST && character.Money >= RESET_COST) return true;
                else return false;
            }
            else return false;
        }
        static public int getCost(int resets)
        {
            if (DYNAMIC_COST) return RESET_COST * (resets + 1);
            else return RESET_COST;
        }
        static public string getClass(int code)
        {
            switch (code)
            {
                case 0: return "Dark Wizard";
                case 1: return "Soul Master";
                case 16: return "Dark Knight";
                case 17: return "Blade Knight";
                case 32: return "Elf";
                case 33: return "Muse Elf";
                case 48: return "Magic Gladiator";
                case 64: return "Dark Lord";
                case 66: return "Lord Emperor";
                case 80: return "Summoner";
                case 81: return "Bloody Summoner";
                case 96: return "Rage Fighter";
                case 98: return "Fist Master";
                default: return "Unknown";
            }
        }
    }
}