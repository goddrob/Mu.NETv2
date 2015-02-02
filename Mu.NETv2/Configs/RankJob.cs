using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Mu.NETv2.Models;

namespace Mu.NETv2.Configs
{
    public class RankJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (var dbcontext = new AccountContext()){
                Rankings.AllRanking = dbcontext.Database.SqlQuery<RankChar>("Select TOP 100 Name,cLevel,Class,Resets from Character ORDER BY Resets desc, cLevel desc").ToList();
                Rankings.lastUpdated = DateTime.Now;
                foreach (var c in Rankings.AllRanking)
                {
                    try
                    {
                        c.Guild = dbcontext.GuildMembers.Single(m => m.Name == c.Name).G_Name;
                    }
                    catch (Exception e)
                    {
                        c.Guild = " ";
                    }
                    
                }
            }
        }
    }
}