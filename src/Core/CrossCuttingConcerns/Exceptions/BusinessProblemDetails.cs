using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;
public class BusinessProblemDetails : ProblemDetailBase
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}
