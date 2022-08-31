using System.Web;
using System.Web.Optimization;

public class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new ScriptBundle("~/bundles/jq-val").Include(
                       "~/Lib/jquery/dist/jquery.js"
                      ,"~/Lib/jquery-validate/dist/jquery.validate.js"
                      ,"~/Lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"));

        //the following creates bundles in debug mode;
        //BundleTable.EnableOptimizations = true;
    }
}