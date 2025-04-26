using MyBase.Models;

namespace MyBase.Repositories
{
    public class BaseRepository
    {
        readonly protected KobzarContext testContext;
        public BaseRepository(KobzarContext testContext) => this.testContext = testContext;
    }
}
