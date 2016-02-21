namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using Services.Data.Contracts;
    using System.Web.Mvc;

    public class NewsLikesController: Controller
    {
        private INewsLikesService newsLikes;

        public NewsLikesController(INewsLikesService newsLikes)
        {
            this.newsLikes = newsLikes;
        }


    }
}