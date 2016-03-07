using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPP_Minneapolis.Models
{
  public enum PermitTypes { Business, Contractor, Organization, Resident };
  
  [JsonObject]
  public class Question
  {
    public string QuestionText { get; set; }
    public bool YesNoQuestion { get; set; }
    public bool YesNoAnswer { get; set; }
    public string AnswerText { get; set; }
    public string AdditionalPermitPDF { get; set;}
  }
}