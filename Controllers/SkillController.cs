using PortflioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortflioProject.Controllers
{
    public class SkillController : Controller
    {
       DbMyPortfolioNightEntities context= new DbMyPortfolioNightEntities();
        public ActionResult SkillList()
        {
            var values=context.Skill.ToList();

            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSkill() {
             return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(Skill skill) {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
             
        }

        [HttpGet]
        public ActionResult DeleteSkill(int id) { 
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id) { 
            var value=context.Skill.Find(id);
            return View(value);
        
        }

    }
}