using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSJ.Models;

namespace DSJ.Controllers
{
    public class TblMenusController : Controller
    {
        private DSJTICKETEntities db = new DSJTICKETEntities();

        // GET: TblMenus
        public ActionResult Index()
        {
            var tblMenus = db.TblMenus.ToList();
            return View(tblMenus);
        }

  
    }
}
