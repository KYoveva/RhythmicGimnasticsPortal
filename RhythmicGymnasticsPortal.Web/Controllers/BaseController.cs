namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Microsoft.AspNet.Identity;
    using RhythmicGymnasticsPortal.Models;
    using Services.Data.Contracts;
    using System.Linq;

    public class BaseController : Controller
    {
        protected IUsersService users;

        public BaseController(IUsersService users)
        {
            this.users = users;
        }

        protected User CurrentUser { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.CurrentUser = this.users.UserById(requestContext.HttpContext.User.Identity.GetUserId()).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}