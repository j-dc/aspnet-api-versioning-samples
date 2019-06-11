using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.SingleEndpoint.Data.V2.Controllers {
    [ApiVersion("2.0")]
    public class ValueController : ODataController {
        public IQueryable<V2.Models.ValueModel> Get() {
            return new V2.Models.ValueModel[] {
                new V2.Models.ValueModel() {ID = 1, Value="Value one", NewProperty ="Only in V2" },
                new V2.Models.ValueModel() {ID = 2, Value="Value two", NewProperty ="Only in V2" }
            }.AsQueryable();
        }

        public V2.Models.ValueModel Get(int key) {
            return new V2.Models.ValueModel() { ID = key, Value = "Choose your id :)", NewProperty = "Only in V2" };
        }
    }
}
