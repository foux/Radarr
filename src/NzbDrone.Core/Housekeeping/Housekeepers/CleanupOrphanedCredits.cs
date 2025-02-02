using Dapper;
using NzbDrone.Core.Datastore;

namespace NzbDrone.Core.Housekeeping.Housekeepers
{
    public class CleanupOrphanedCredits : IHousekeepingTask
    {
        private readonly IMainDatabase _database;

        public CleanupOrphanedCredits(IMainDatabase database)
        {
            _database = database;
        }

        public void Clean()
        {
            using (var mapper = _database.OpenConnection())
            {
                mapper.Execute(@"DELETE FROM ""Credits""
                                     WHERE ""Id"" IN (
                                     SELECT ""Credits"".""Id"" FROM ""Credits""
                                     LEFT OUTER JOIN ""Movies""
                                     ON ""Credits"".""MovieId"" = ""Movies"".""Id""
                                     WHERE ""Movies"".""Id"" IS NULL)");
            }
        }
    }
}
