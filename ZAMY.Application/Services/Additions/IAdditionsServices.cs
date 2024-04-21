namespace ZAMY.Application.Services.Additions
{
    public interface IAdditionsServices
    {
        Addition? GetById(int id);
        IEnumerable<Addition>? GetAll(int Mealid);
        Addition? Add(Addition addition,IFormFile img);
        Addition? Update(int id, Addition updatedAddition, IFormFile img);
        bool Delete(int id);
        bool ToggleStatus(int id);
    }
}
