namespace RhythmicGymnasticsPortal.Services.Data
{
    using System.Linq;
    using Models;
    using RhythmicGymnasticsPortal.Data.Repositories;
    using Contracts;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> AllUsers()
        {
            return this.users.All();
        }

        public IQueryable<User> UserById(string id)
        {
            return this.users.All()
                .Where(x => x.Id == id);
        }
    }
}
