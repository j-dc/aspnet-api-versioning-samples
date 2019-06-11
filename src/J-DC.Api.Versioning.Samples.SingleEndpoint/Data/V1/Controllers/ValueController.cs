using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.SingleEndpoint.Data.V1.Controllers {

    [ApiVersion("1.0")]
    public class ValueController : ODataController {
            public IQueryable<V1.Models.ValueModel> Get() {
            return new V1.Models.ValueModel[] {
                new V1.Models.ValueModel() {ID = 1, Value = "Value One"},
                new V1.Models.ValueModel() {ID = 2, Value = "Value two" }
            }.AsQueryable();
        }

        public V1.Models.ValueModel Get(int key) {
            return new V1.Models.ValueModel() { ID = key };
        }


    }
}
