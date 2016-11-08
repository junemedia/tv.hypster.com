using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_tv.Controllers
{
    public class slideshowController : Controller
    {


        //
        // GET: /slideshow/
        //----------------------------------------------------------------------------------------------------------
        [OutputCache(Duration=120, VaryByParam="none")]
        public ActionResult _slideshow()
        {
            hypster_tv_DAL.videoFeaturedManager fManager = new hypster_tv_DAL.videoFeaturedManager();
            List<hypster_tv_DAL.videoFeaturedSlideshow> video_list = fManager.getFeaturedVideos();
            
            return View(video_list);
        }
        //----------------------------------------------------------------------------------------------------------




    }
}
