namespace Accountant.API.WebAPI.Interfaces
{
    public interface IApiLogicAggregator
    {
        IAuthenticateUserLogic AuthenticateUserLogic { get; }
        IApiProcessLogic ApiProcessLogic { get; }
    }
}
