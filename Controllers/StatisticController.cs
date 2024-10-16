using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortflioProject.Models;

namespace PortflioProject.Controllers
{
    public class StatisticController : Controller
    {
        DbMyPortfolioNightEntities context= new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            ViewBag.totalMessageCount = context.Contact.Count();
            ViewBag.messageIsReadTrueCount = context.Contact.Where(x=>x.IsRead==true).Count();
            ViewBag.messageIsReadFalseCount = context.Contact.Where(x => x.IsRead == false).Count();
            ViewBag.skillCount=context.Skill.Count();
            ViewBag.skillRateSum = context.Skill.Sum(x=>x.Rate);
            ViewBag.skillRateAvg= context.Skill.Average(x=>x.Rate);
            var maxRate = context.Skill.Max(x=>x.Rate);
            ViewBag.maxRateSkillName= context.Skill.Where(x => x.Rate == maxRate).Select(x=>x.SkillName).FirstOrDefault();
            ViewBag.getMessageCountBySubjectReferances = context.Contact.Where(x => x.Subject == "Deneyim").Count();
            return View();
        }
    }
}