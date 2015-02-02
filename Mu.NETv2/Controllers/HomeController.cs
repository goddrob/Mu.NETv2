using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mu.NETv2.Configs;
using Mu.NETv2.Models;

namespace Mu.NETv2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //[OutputCache(Duration = 900)]
        public ActionResult Ranking()
        {
            List<RankChar> rank_all = null;
            string updated = null;
            bool needUpdate = true;
            if (HttpContext.Cache["rank_all"] != null && HttpContext.Cache["updated"] != null && HttpContext.Cache["up_datetime"] != null)
            {
                if ((int)DateTime.Now.Subtract((DateTime)HttpContext.Cache["up_datetime"]).TotalMinutes < 15)
                {
                    rank_all = (List<RankChar>)HttpContext.Cache["rank_all"];
                    updated = (string)HttpContext.Cache["updated"];
                    needUpdate = false;
                }
            }
            if (needUpdate)
            {
                // List<Character> chary = new List<Character>();
                //ViewBag.Updated = (int)DateTime.Now.Subtract(Rankings.lastUpdated).TotalMinutes;
                rank_all = new List<RankChar>();
                updated = DateTime.Now.ToUniversalTime().ToString("HH:mm:ss");
                using (var context = new AccountContext())
                {
                    List<Character> chary = context.Characters.OrderByDescending(c => c.cLevel).OrderByDescending(c => c.Resets).Take(100).ToList();
                    foreach (var c in chary)
                    {
                        rank_all.Add(new RankChar() { Class = c.Class, cLevel = c.cLevel, Name = c.Name, Resets = c.Resets });
                        try
                        {
                            rank_all.Last().Guild = context.GuildMembers.Single(m => m.Name == c.Name).G_Name;
                        }
                        catch (Exception e)
                        {
                            rank_all.Last().Guild = " ";
                        }
                    }
                }
                HttpContext.Cache["rank_all"] = rank_all;
                HttpContext.Cache["updated"] = updated;
                HttpContext.Cache["up_datetime"] = DateTime.Now;
            }
            ViewBag.Updated = updated;
            ViewBag.Characters = rank_all;
            return View();
        }
    }
}
