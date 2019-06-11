using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.SingleEndpoint.Data.V17.Controllers {

    [ApiVersion("17")]
    public class ValueController : ODataController {
            public IQueryable<Models.ValueModel> Get() {
            return new Models.ValueModel[] {
                new Models.ValueModel() {ID = 1, Value = "Value One"},
                new Models.ValueModel() {ID = 2, Value = "Value two" }
            }.AsQueryable();
        }

        public Models.ValueModel Get(int key) {
            return new V17.Models.ValueModel() { ID = key };
        }


    }
}
