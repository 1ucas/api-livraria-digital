
namespace LivrariaApiServices
{
    public class AutenticacaoService : BaseService
    {
        public AutenticacaoService(string authToken) : base(authToken)
        {
            BaseRoute = "https://apilivrariaauth20181002115700.azurewebsites.net/";
        }
    }
}
