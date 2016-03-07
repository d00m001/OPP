using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPP_Minneapolis.Models
{
  public class Permit
  {
    public PermitTypes PermitType { get; set; }
    public string Name { get; set; }
    public string PDFLink { get; set; }
    public List<Question> QuestionList { get; set; }

    public Permit()
    {
      QuestionList = new List<Question>();
    }
  }
}