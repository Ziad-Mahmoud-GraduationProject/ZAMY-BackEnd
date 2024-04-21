namespace ZAMY.Application.Services.Choices
{
    public interface IChoicesServices
    {
        Choice? GetById(int id);
        IEnumerable<Choice>? GetAll(int Mealid);
        Choice? Add(Choice choice);
        Choice? Update(int id, Choice updatedchoice);
        bool Delete(int id);
        bool ToggleStatus(int id);
    }
}
