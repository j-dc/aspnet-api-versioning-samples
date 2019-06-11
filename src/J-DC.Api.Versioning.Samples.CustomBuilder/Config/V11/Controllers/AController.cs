using JDC.Api.Versioning.Samples.CustomBuilder.Custom;
using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.CustomBuilder.Config.V11.Controllers {
    [EndPoint(CST.EndPointName)]
    [ApiVersion(CST.V11)]
    public class AController : ODataController {
        public IQueryable<Models.AModel> Get() {
            return new Models.AModel[] {
                new Models.AModel() {ID = 1 },
                new Models.AModel() {ID = 2 }
            }.AsQueryable();
        }

        public Models.AModel Get(int key) {
            return new Models.AModel() { ID = key };
        }

    }
}
