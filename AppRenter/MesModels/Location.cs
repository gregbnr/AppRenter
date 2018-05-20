using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace AppRenter.MesModels
{
  public class Location
  {
    [JsonProperty("idCl")]
    public string idCl { get; set; }
    [JsonProperty("idVoit")]
    public string idVoit { get; set; }
    [JsonProperty("dateLoc")]
    public string dateLoc { get; set; }
    [JsonProperty("dateFinLoc")]
    public string dateFinLoc { get; set; }
  }
}
