using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_02.Data.V2.Controllers {
    [ApiVersion("2.0")]
    public class ValuesController : ODataController {
        public IQueryable<Models.ValueModel> Get() {
            return new Models.ValueModel[] {
                new Models.ValueModel() {ID = 2 }
            }.AsQueryable();
        }

        public Models.ValueModel Get(int key) {
            return new Models.ValueModel() { ID = key };
        }
    }
}
