using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_03.Data.V2.Controllers {

    [ApiVersion("2.0")]
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
