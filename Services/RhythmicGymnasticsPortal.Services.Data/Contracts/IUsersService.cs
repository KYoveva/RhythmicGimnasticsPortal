namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface IUsersService
    {
        IQueryable<User> AllUsers();

        User UserById(string id);
    }
}
