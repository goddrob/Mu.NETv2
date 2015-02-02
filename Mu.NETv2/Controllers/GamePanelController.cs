using Mu.NETv2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mu.NETv2.Models;
using Mu.NETv2.Configs;
using System.Data.Common;
using System.Data.SqlClient;

namespace Mu.NETv2.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class GamePanelController : Controller
    {
        //
        // GET: /GamePanel/

        public ActionResult Index(ResetModel model)
        {
            ResetModel mdl;
            AccountCharacter account = GetAccountCharacter();
            if (TempData["r_model"] != null)
            {
                mdl = (ResetModel)TempData["r_model"];
            }
            else
            {
                mdl = new ResetModel();
            }
            List<Character> chars = new List<Character>();
            if (account.GameID1 != null) chars.Add(GetCharacter(account.GameID1));
            if (account.GameID2 != null) chars.Add(GetCharacter(account.GameID2));
            if (account.GameID3 != null) chars.Add(GetCharacter(account.GameID3));
            if (account.GameID4 != null) chars.Add(GetCharacter(account.GameID4));
            if (account.GameID5 != null) chars.Add(GetCharacter(account.GameID5));
            ViewBag.Chars = chars;
            return View(mdl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetCh(ResetModel model)
        {
            if (ModelState.IsValid)
            {
                ResetModel mdl = new ResetModel();
                mdl.errorMessage = ResetChar(model.name);
                TempData["r_model"] = mdl;
            }
            return RedirectToAction("Index");
        }
        private string ResetChar(string Name)
        {
            if (!CheckOnline()) return "You must log out before reseting.";
            using (var context = new Models.AccountContext())
            {

                Character character = context.Characters.Find(Name);
                if (character == null) return "Character not found. Contact admin.";
                if (character.AccountID != User.Identity.Name) return "This character doesn't belong to you. Contact admin."; //Should never happen
                else
                {
                    //if (!Config.isResetable(character) && !CheckOnline()) return false;
                    if (character.cLevel < Config.RESET_LEVEL) return "You need "+Config.RESET_LEVEL.ToString()+" level to reset. You are only "+character.Resets;
                    else if (character.Money < Config.getCost(character.Resets)) return "You don't have enough money.\nYou need "+(Config.getCost(character.Resets)-character.Money).ToString()+" more zen to reset.";
                    else
                    {
                        try
                        {
                            //var args = new DbParameter[]{
                            //    new SqlParameter{ParameterName="name",Value=character.Name},
                            //    new SqlParameter{ParameterName="acc",Value=User.Identity.Name},
                            //    new SqlParameter{ParameterName="cost",Value=Config.getCost(character.Resets)}
                            //};
                            //context.Database.ExecuteSqlCommand("Update Character SET cLevel=1, Resets=Resets+1, Money=Money - @cost, Experience = 0, MapNumber = 0, MapPosX = 182, MapPosY = 128 WHERE AccountID=@acc and Name=@name", args);
                            character.cLevel = 1;
                            character.Resets += 1;
                            character.Money -= Config.getCost(character.Resets);
                            character.Experience = 0;
                            character.MapNumber = 0;
                            character.MapPosX = 182;
                            character.MapPosY = 128;
                            context.SaveChanges();
                            context.Entry(character).GetDatabaseValues();
                        }
                        catch (Exception e)
                        {

                            return "A problem occured. Contact admin with Error Code:"+e.HResult.ToString();
                        }
                    }
                }
            }

            return Name+" succesfully reseted.";
        }
        private AccountCharacter GetAccountCharacter(){
            using (var context = new Models.AccountContext()) {
                return context.AccountCharacters.Single(c => c.Id == User.Identity.Name);
            }
        }
        private Character GetCharacter(string name)
        {
            using (var context = new Models.AccountContext())
            {
                return context.Characters.Single(c => c.Name == name);
            }
        }
        private bool CheckOnline()
        {
            using (var context = new Models.AccountContext())
            {
                if (context.Status.Single(c => c.memb___id == User.Identity.Name).ConnectStat != 0) return false;
                else return true;
            }
        }
        private Guild getGuild(string name)
        {
            using (var context = new Models.AccountContext())
            {
                return context.Guilds.Single(g => g.G_Name == name);
            }
        }

    }
}
