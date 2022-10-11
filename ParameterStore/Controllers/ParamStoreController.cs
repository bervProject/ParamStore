using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace ParameterStore.Controllers;

[ApiController]
[Route("[controller]")]
public class ParamStoreController : ControllerBase
{
    private readonly ILogger<ParamStoreController> _logger;
    private readonly IAmazonSimpleSystemsManagement _ssmClient;

    public ParamStoreController(IAmazonSimpleSystemsManagement ssmClient, ILogger<ParamStoreController> logger)
    {
        _ssmClient = ssmClient;
        _logger = logger;
    }

    [HttpGet(Name = "GetParameterStore")]
    public async Task<string> GetAsync([FromQuery] string parameterName)
    {
        var request = new GetParameterRequest() {
            Name = parameterName
        };
        var param = await _ssmClient.GetParameterAsync(request);
        return param.Parameter.Value;
    }
}
