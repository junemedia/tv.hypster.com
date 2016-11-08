using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_tv.Controllers
{
    public class v1Controller : Controller
    {
        //
        // GET: /video/
        //----------------------------------------------------------------------------------------------------------
        [OutputCache(Duration = 120, VaryByParam = "video_id")]
        public ActionResult getVideo(string video_id)
        {
            hypster_tv.ViewModels.getVideoViewModel viewModel = new ViewModels.getVideoViewModel();



            hypster_tv_DAL.videoClipManager videoManager = new hypster_tv_DAL.videoClipManager();
            viewModel.video = videoManager.getVideoByGUID(video_id);
            viewModel.comments_list = videoManager.GetVideoComments(viewModel.video.videoClip_ID);


            //add new video view
            videoManager.AddVideoView(viewModel.video.videoClip_ID, viewModel.video.ViewsNum + 1);


            return View(viewModel);
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        [OutputCache(Duration = 120, VaryByParam = "none")]
        public ActionResult _getVideoBottomLinks()
        {
            hypster_tv.ViewModels.getVideoBottomLinksViewModel model = new ViewModels.getVideoBottomLinksViewModel();



            hypster_tv_DAL.videoClipManager videoManager = new hypster_tv_DAL.videoClipManager();
            int numberOfClips = 0;
            numberOfClips = videoManager.getNumberOfVideoClips();
            model.NumOfVideos = 0;

            model.TopVideos = videoManager.getTopRatedVideos_cache(12);
            model.NewVideos = videoManager.getNewVideos_cache(12);


            return View(model);
        }
        //----------------------------------------------------------------------------------------------------------

    }
}
