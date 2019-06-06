using Data_Layer.Repository;

namespace Data_Layer.Interface
{
    public interface IUserStatsRepository
    {
        UserStats GetUserStats(string userName);
    }
}