using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_01.MSVersioningMulti.Config.V12.Controllers {
    [ApiVersion("12")]
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
