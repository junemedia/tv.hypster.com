using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_tv.Controllers
{
    [Authorize]
    public class uploadController : Controller
    {


        //
        // GET: /upload/
        //----------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //----------------------------------------------------------------------------------------------------------







        //
        // POST: /upload/
        //----------------------------------------------------------------------------------------------------------
        [HttpPost]
        public ActionResult Index(hypster_tv_DAL.videoClip clipToAdd, HttpPostedFileBase file)
        {
            string file_GUID = "";

            if (file != null && file.ContentLength > 0 )
            {
                if (clipToAdd.Name != null && clipToAdd.Name != "")
                {
                    
                    file_GUID = System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 23);
                    var fileName = System.IO.Path.GetFileName(file.FileName);
                    var extension = System.IO.Path.GetExtension(file.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/uploads_pending"), file_GUID + extension);
                    file.SaveAs(path);


                    clipToAdd.Guid = file_GUID;
                    clipToAdd.UploadDate = DateTime.Now;
                    clipToAdd.Duration = 0;
                    clipToAdd.UploadedByName = User.Identity.Name;
                    clipToAdd.Status = -1; //status (-1) - is pending need to be reviwed to have proper video format



                    hypster_tv_DAL.Hypster_Entities hyDB = new hypster_tv_DAL.Hypster_Entities();
                    hyDB.AddTovideoClips(clipToAdd);
                    hyDB.SaveChanges();
                    

                    //return RedirectToAction("Index", "Home");
                    return RedirectToAction("UploadConfirmation", "upload");
                }
                else
                    ModelState.AddModelError("", "Please enter video name");
            }
            else
            {
                ModelState.AddModelError("", "Please select video");
            }



            return View();
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public ActionResult UploadConfirmation()
        {
            return View();
        }
        //----------------------------------------------------------------------------------------------------------


    }
}
