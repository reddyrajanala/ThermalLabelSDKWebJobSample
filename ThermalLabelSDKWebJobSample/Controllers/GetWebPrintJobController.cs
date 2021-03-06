﻿using System.Web.Mvc;
using Neodynamic.SDK.Printing;
 
public class GetWebPrintJobController : Controller
{
 
    [AllowAnonymous]
    public void Index()
    {
        //Create a WebPrintJob obj 
        WebPrintJob webPj = new WebPrintJob();
  
        //set a ThermalLabel obj 
        webPj.ThermalLabel = GenerateBasicThermalLabel();
  
        //display print dialog to the client  
        webPj.ShowPrintDialog = true;
         
        //Serialize WebPrintJob and send it back to the client
        //so it can be processed by the TLClientPrint utility
        HttpContext.Response.ContentType = "text/plain";
        HttpContext.Response.Write(webPj.ToString());
        HttpContext.Response.Flush();
        HttpContext.Response.End();
         
    }
 
    private ThermalLabel GenerateBasicThermalLabel()
    {
        //Define a ThermalLabel object and set unit to inch and label size
        ThermalLabel tLabel = new ThermalLabel(Neodynamic.SDK.Printing.UnitType.Inch, 4, 3);
        tLabel.GapLength = 0.2;
  
        //Define a TextItem object
        TextItem txtItem = new TextItem(0.2, 0.2, 2.5, 0.5, "Thermal Label Test");
  
        //Define a BarcodeItem object
        BarcodeItem bcItem = new BarcodeItem(0.2, 1, 2, 1, BarcodeSymbology.Code128, "ABC 12345");
        //Set bars height to .75inch
        bcItem.BarHeight = 0.75;
        //Set bars width to 0.0104inch
        bcItem.BarWidth = 0.0104;
  
        //Add items to ThermalLabel object...
        tLabel.Items.Add(txtItem);
        tLabel.Items.Add(bcItem);
  
  
        return tLabel;
    }
}