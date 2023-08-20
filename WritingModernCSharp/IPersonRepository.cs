namespace WritingModernCSharp;

public interface IPersonRepository
{
	Person? Retrieve(Guid id);
}