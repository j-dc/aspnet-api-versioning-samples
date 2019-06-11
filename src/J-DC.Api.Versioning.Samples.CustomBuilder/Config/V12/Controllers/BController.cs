using JDC.Api.Versioning.Samples.CustomBuilder.Custom;
using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.CustomBuilder.Config.V12.Controllers {
    [EndPoint(CST.EndPointName)]
    [ApiVersion(CST.V12)]
    public class BController : ODataController {
        public IQueryable<Models.BModel> Get() {
            return new Models.BModel[] {
                new Models.BModel() {ID = 1 },
                new Models.BModel() {ID = 2 }
            }.AsQueryable();
        }

        public Models.BModel Get(int key) {
            return new Models.BModel() { ID = key };
        }
    }
}
