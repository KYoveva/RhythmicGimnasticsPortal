namespace RhythmicGymnasticsPortal.Web.Areas.Private.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Users;
    using Services.Data.Contracts;
    using Services.Web.Contracts;
    using Web.Controllers;

    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(IUsersService users)
            : base(users)
        {
        }

        [HttpGet]
        public ActionResult GetUserProfilePartial()
        {
            var userName = this.CurrentUser.UserName;

            var userData = this.users
                        .UserById(this.CurrentUser.Id)
                        .ProjectTo<UsersViewModel>()
                        .FirstOrDefault();

            return this.PartialView("_UserProfilePartial", userData);
        }
    }
}