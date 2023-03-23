using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PetShopAdmin.Controllers
{
    

    public class UploadFilesController : Controller
    {
        private IHostingEnvironment Environment;

        public UploadFilesController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public ActionResult UploadSingleFile(IFormFile file)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            try
            {
                if (file.Length > 0)
                {
                    DateTime currentTime = DateTime.UtcNow;
                    long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
                    string _FileName = Path.GetFileName(file.FileName);
                    _FileName = unixTime + _FileName;

                    string path = Path.Combine(wwwPath, "img");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (FileStream stream = new FileStream(Path.Combine(path, _FileName), FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var return_path = Path.Combine("img", _FileName);
                    return Content(return_path);
                }
                throw new Exception();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
