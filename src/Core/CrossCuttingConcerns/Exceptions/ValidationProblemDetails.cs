using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ValidationProblemDetails : ProblemDetailBase
{
    public object Errors { get; set; }

    public override string ToString() => JsonConvert.SerializeObject(this);
}
