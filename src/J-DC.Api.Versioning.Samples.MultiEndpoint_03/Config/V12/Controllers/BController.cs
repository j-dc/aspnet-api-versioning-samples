using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_03.Config.V12.Controllers {

    [ApiVersion("12")]
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
