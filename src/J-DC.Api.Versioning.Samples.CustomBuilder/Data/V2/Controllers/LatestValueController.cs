using JDC.Api.Versioning.Samples.CustomBuilder.Custom;
using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.CustomBuilder.Data.V2.Controllers {
    [EndPoint(CST.EndPointName)]
    [ApiVersion(CST.V2)]
    public class LatestValueController : ODataController {
        public IQueryable<Models.LatestValueModel> Get() {
            return new Models.LatestValueModel[] {
                new Models.LatestValueModel() {ID = 1 },
                new Models.LatestValueModel() {ID = 2 }
            }.AsQueryable();
        }

        public Models.LatestValueModel Get(int key) {
            return new Models.LatestValueModel() { ID = key };
        }
    }
}
