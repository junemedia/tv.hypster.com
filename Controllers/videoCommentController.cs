using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_tv.Controllers
{
    public class videoCommentController : Controller
    {
        //
        // GET: /videoComment/
        //----------------------------------------------------------------------------------------------------------
        [HttpPost]
        public ActionResult SubmitVideoComment(hypster_tv_DAL.videoComment p_comment, string video_guid)
        {
            hypster_tv_DAL.Hypster_Entities hyDB = new hypster_tv_DAL.Hypster_Entities();
            hypster_tv_DAL.memberManagement memberManager = new hypster_tv_DAL.memberManagement();


            
            p_comment.comment = System.Text.RegularExpressions.Regex.Replace(p_comment.comment, @"<(.|\n)*?>", string.Empty);

            p_comment.ipAddress = IpAddress();
            p_comment.status = (int)hypster_tv_DAL.newsCommentStatus.NoActive;
            p_comment.user_ID = memberManager.getMemberByUserName(User.Identity.Name).id;
            p_comment.userName = User.Identity.Name;
            p_comment.postDate = DateTime.Now;
            

            hyDB.videoComments.AddObject(p_comment);
            hyDB.SaveChanges();
            




            //need to reset data cache (if exist)
            // this will allow to show new comment
            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["VideoComment_For_Tv_" + p_comment.videoClip_ID] != null)
                i_chache.Remove("VideoComment_For_Tv_" + p_comment.videoClip_ID);
            




            return RedirectToAction("getVideo", "video", new { @video_id = video_guid });
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Service function - gives user ip address
        /// </summary>
        /// <returns></returns>
        private string IpAddress()
        {
            string strIpAddress;
            strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIpAddress == null) strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
            return strIpAddress;
        }
        //----------------------------------------------------------------------------------------------------------


    }
}
