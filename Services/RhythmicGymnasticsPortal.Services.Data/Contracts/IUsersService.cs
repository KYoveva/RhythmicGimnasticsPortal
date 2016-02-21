namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using RhythmicGymnasticsPortal.Models;

    public interface IUsersService
    {
        IQueryable<User> AllUsers();

        User UserById(string id);
    }
}
