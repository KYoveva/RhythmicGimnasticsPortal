namespace RhythmicGymnasticsPortal.Services.Data
{
    using System.Linq;
    using Models;
    using RhythmicGymnasticsPortal.Services.Data.Contracts;
    using RhythmicGymnasticsPortal.Data.Repositories;

    public class UsersService : IUsersService
    {
        private IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> AllUsers()
        {
            return this.users.All();
        }

        public User UserById(string id)
        {
            return this.users.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
