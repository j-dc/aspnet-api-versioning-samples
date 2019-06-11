using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.SingleEndpoint.Data.V18.Controllers {
    [ApiVersion("18")]
    public class ValueController : ODataController {
        public IQueryable<Models.ValueModel> Get() {
            return new Models.ValueModel[] {
                new Models.ValueModel() {ID = 1, Value="Value one", NewProperty ="Only in V18" },
                new Models.ValueModel() {ID = 2, Value="Value two", NewProperty ="Only in V18" }
            }.AsQueryable();
        }

        public Models.ValueModel Get(int key) {
            return new Models.ValueModel() { ID = key, Value = "Choose your id :)", NewProperty = "Only in V18" };
        }
    }
}
