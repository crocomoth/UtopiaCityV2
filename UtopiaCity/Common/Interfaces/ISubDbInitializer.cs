using UtopiaCity.Data;

namespace UtopiaCity.Common.Interfaces
{
    public interface ISubDbInitializer
    {
        void InitializeSet(AppDbContext context);
        void ClearSet(AppDbContext context);
    }
}
