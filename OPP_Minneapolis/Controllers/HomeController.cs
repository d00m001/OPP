using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPP_Minneapolis.Models;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;

namespace OPP_Minneapolis.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    public ActionResult FindPermit()
    {
      return View();
    }

    [HttpGet]
    public ActionResult RefreshPermitList(string id)
    {
      Permits permitList = new Permits();
      Permits filteredList = new Permits();
      List<PermitTypes> permitTypeList = null;
      string json;
      string PermitTypes = id;
      if (PermitTypes != null)
      {
        permitTypeList = new List<PermitTypes>();
        foreach(string pt in PermitTypes.Split('|').ToList<string>())
        {
          switch(pt) {
            case "Business":
              permitTypeList.Add(Models.PermitTypes.Business);
              break;
            case "Residential":
              permitTypeList.Add(Models.PermitTypes.Resident);
              break;
            case "Organization":
              permitTypeList.Add(Models.PermitTypes.Organization);
              break;
            case "Contractor":
              permitTypeList.Add(Models.PermitTypes.Contractor);
              break;
          }
        }
      }
      else
      {
        permitTypeList = new List<PermitTypes>() {Models.PermitTypes.Business, Models.PermitTypes.Resident, Models.PermitTypes.Organization, Models.PermitTypes.Contractor};
      }
      //TODO: Parse JSON Data based on Permit Types
      using (StreamReader r = new StreamReader(HttpContext.Server.MapPath("~/App_Data/Permits.json")))
      {
        json = r.ReadToEnd().Replace("\r", "").Replace("\n", "");
        permitList = JsonConvert.DeserializeObject<Permits>(json);
        foreach(Permit p in permitList)
        {
          if (permitTypeList.Contains(p.PermitType))
          {
            filteredList.Add(p);
          }
        }
      }
      return PartialView(@"~/Views/Shared/EditorTemplates/_PermitLinks.cshtml", filteredList);
    }

    [HttpGet]
    public ActionResult LoadApplication(string id)
    {
      string pdfName = id;

      ViewBag.ApplicationName = id;

      switch (id)
      {
          
        case "Parade":
          ViewBag.PDF = "/Permits/ParadePermitFillable.pdf";
          break;
        case "Block":
          ViewBag.PDF = "/Permits/BlockEvent.pdf";
          break;
        case "Plaza":
          ViewBag.PDF = "/Permits/PlazaPermit.pdf";
          
          break;
      }

      return View();
    }

    [HttpPost]
    public ActionResult LoadApplication()
    {
      return RedirectToAction("DrawMap");
    }

    [HttpGet]
    public ActionResult DrawMap(string id)
    {
      return View();
    }

    [HttpPost]
    public ActionResult DrawMap()
    {
      return RedirectToAction("CompleteApplication");
    }

    [HttpGet]
    public ActionResult CompleteApplication(string id)
    {
      return View();
    }

    [HttpPost]
    public ActionResult CompleteApplication()
    {
      return RedirectToAction("ThankYou");
    }

    [HttpGet]
    public ActionResult ThankYou()
    {
      return View();
    }
  }
}