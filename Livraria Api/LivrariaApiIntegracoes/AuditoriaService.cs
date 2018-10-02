using System;
using System.Collections.Generic;

namespace LivrariaApiServices
{
    public class AuditoriaService : BaseService
    {
        public AuditoriaService(string authToken) : base(authToken)
        {
            BaseRoute = "";
        }
    }
}
