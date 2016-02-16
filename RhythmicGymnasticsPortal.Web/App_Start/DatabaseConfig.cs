namespace RhythmicGymnasticsPortal.Web.App_Start
{
    using System.Data.Entity;
    using RhythmicGymnasticsPortal.Data;
    using RhythmicGymnasticsPortal.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RhythmicGymnasticsPortalDbContext, Configuration>());
            RhythmicGymnasticsPortalDbContext.Create().Database.Initialize(true);
        }
    }
}