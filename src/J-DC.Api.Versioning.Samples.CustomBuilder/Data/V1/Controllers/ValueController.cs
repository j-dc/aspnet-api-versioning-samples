using JDC.Api.Versioning.Samples.CustomBuilder.Custom;
using Microsoft.AspNet.OData;
using Microsoft.Web.Http;
using System.Linq;

namespace JDC.Api.Versioning.Samples.CustomBuilder.Data.V1.Controllers {

    [EndPoint(CST.EndPointName)]
    [ApiVersion(CST.V1)]

    public class ValueController : ODataController {
        public IQueryable<Models.ValueModel> Get() {
            return new Models.ValueModel[] {
                new Models.ValueModel() {ID = 1 },
                new Models.ValueModel() {ID = 2 }
            }.AsQueryable();
        }
        public Models.ValueModel Get(int key) {
            return new Models.ValueModel(){ ID = key };
        }


    }
}
