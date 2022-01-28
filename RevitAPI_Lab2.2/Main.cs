using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_Lab2._2
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id)
            .OfCategory(BuiltInCategory.OST_PipeCurves)
            .Cast<FamilyInstance>()
            .ToList();


            TaskDialog.Show("Количество труб на активном виде:", familyInstances.Count.ToString());

            return Result.Succeeded;
        }
    }
}
