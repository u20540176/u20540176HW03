using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u20540176_HW03.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        [HttpGet]
        public ActionResult Images()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Images/"));
            List<Models.FileModel> files = new List<Models.FileModel>(); // create a list of files
            foreach (string filePath in filePaths)
            {
                files.Add(new Models.FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Images");
        }

    }
}
    
