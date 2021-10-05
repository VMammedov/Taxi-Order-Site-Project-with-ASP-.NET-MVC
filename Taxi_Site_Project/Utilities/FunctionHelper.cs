using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Taxi_Site_Project.Utilities
{
    public static class FunctionHelper
    {
        public static string UpdateImage(HttpRequestBase request, string oldimg)
        {
            string path;
            if (string.IsNullOrEmpty(request.Files[0].FileName) == false)
            {
                string filename = Path.GetFileName(request.Files[0].FileName);
                string extension = Path.GetExtension(request.Files[0].FileName);
                path = "~/Images/" + filename + extension;
                try
                {
                    if (System.IO.File.Exists(request.MapPath(oldimg)))
                    {
                        System.IO.File.Delete(request.MapPath(oldimg));
                    }
                }
                finally
                {
                    request.Files[0].SaveAs(request.MapPath(path));
                    path = "/Images/" + filename + extension;
                }
                return path;
            }
            else
                return oldimg;
        }
    }
}