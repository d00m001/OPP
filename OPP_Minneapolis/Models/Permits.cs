using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPP_Minneapolis.Models
{
  [JsonObject]
  public class Permits : IEnumerable<Permit>
  {
     public List<Permit> PermitList { get; private set; }

    public Permits()
    {
      PermitList = new List<Permit>();
    }

    public void Add(Permit item)
    {
       PermitList.Add(item);
    }

    public IEnumerator<Permit> GetEnumerator()
    {
        return PermitList.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
  }
}